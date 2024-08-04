using System.Collections;
using System.Collections.Generic;
using SunHeTBS;
using UniFramework.Event;
using UnityEngine;

public class MainCharacterController : MonoBehaviour
{
    Rigidbody rb;
    Animator animator;
    CharacterController ctrl;
    public static MainCharacterController Inst;
    private void Awake()
    {
        Inst = this;
    }
    private void OnDestroy()
    {
        Inst = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.heroCtrl = this;
        ctrl = this.GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        ResetHP();
        ResetPosition();

        GameManager.Instance.DoLoadSavedGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.running == false)
        {
            return;
        }
        //ProcessRotate();
        //ProcessMove();
        CheckFallen();

        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    //DoJump();
        //}
        //this.isGrounded = CheckGrounded();

        // ProcessJump();
    }

    public float addForceSpeed = 400f;
    public float moveSpeed = 1f;
    #region move by axis
    void ProcessMove()
    {
        float axisH = Input.GetAxis("Horizontal");
        float axisV = Input.GetAxis("Vertical");
        animator.SetFloat("moveH", axisH);
        animator.SetFloat("moveV", axisV);
        if (isAxisSmall(axisV) && isAxisSmall(axisH))
        {
            animator.SetBool("noMove", true);
            rb.velocity = Vector3.zero;
        }
        else
        {
            animator.SetBool("noMove", false);


            Vector3 forwardVect = this.transform.forward * axisV;
            Vector3 rightVect = this.transform.right * axisH;
            Vector3 moveVect = (forwardVect + rightVect) * Time.deltaTime * moveSpeed;
            //this.transform.position += moveVect;
            ctrl.Move(moveVect);
        }
    }
    bool isAxisSmall(float value)
    {
        return Mathf.Abs(value) < 0.05f;
    }
    #endregion

    #region rotate by mouse
    bool holdingMouseR = false;

    private Vector3 rotationSpeed;
    public float sensivity = 1;
    void ProcessRotate()
    {
        //if (Input.GetMouseButtonUp(1))
        //{
        //    //transform.Rotate(Vector3.zero * Time.deltaTime);

        //}
        //else if (Input.GetMouseButton(1))
        //{
        //    float y = Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        //    rotationSpeed.y = y;
        //    transform.Rotate(rotationSpeed * Time.deltaTime);
        //}
    }
    #endregion

    void CheckFallen()
    {
        bool fallen = this.transform.localPosition.y < -3;
        if (fallen)
            GameManager.Instance.GameOver(GameOverReason.Fallen);
    }


    public void ResetPosition()
    {

        this.transform.position = new Vector3(-15, 0, -29);
    }
    #region Health system
    public float HP = 0;
    public float HPMax = 100;
    public void ResetHP()
    {
        this.HP = HPMax;
    }
    void AddHP(float value)
    {
        this.HP += value;
        ChechHP();
    }
    void ChechHP()
    {
        if (this.HP <= 0)
        {
            //trigger game over
            GameManager.Instance.GameOver(GameOverReason.Died);
        }
        if (this.HP > HPMax)
        {
            HP = HPMax;
        }
    }
    #endregion

    #region collision events

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision Entered with " + collision.gameObject.name);
        var item = collision.gameObject.GetComponent<InteractiveItem>();
        if (item != null)
        {
            item.MakeInvisible();
            switch (item.itemType)
            {
                case ItemType.TimePotion:
                    GameManager.Instance.AddTime(10);
                    UniEvent.SendMessage(GameEventDefine.PickTimer, new GameEventData(GameEventDefine.PickTimer, 1));
                    break;
                case ItemType.Coin:
                    GameManager.Instance.AddCoin(10);
                    UniEvent.SendMessage(GameEventDefine.PickGold, new GameEventData(GameEventDefine.PickGold, 1));
                    break;
                case ItemType.Score:
                    GameManager.Instance.AddScore(5);
                    UniEvent.SendMessage(GameEventDefine.PickStar, new GameEventData(GameEventDefine.PickStar, 1));
                    break;
                case ItemType.HealthPotion: AddHP(10);
                    UniEvent.SendMessage(GameEventDefine.PickRedPotion, new GameEventData(GameEventDefine.PickRedPotion, 1));
                    break;
                case ItemType.ToxicPotion: AddHP(-10);
                    UniEvent.SendMessage(GameEventDefine.PickToxicPotion, new GameEventData(GameEventDefine.PickToxicPotion, 1));
                    break;
            }
        }



    }
    #endregion
}
