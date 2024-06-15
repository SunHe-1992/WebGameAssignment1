using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractiveItem : MonoBehaviour
{
    [SerializeField]
    public ItemType itemType = ItemType.Default;

    public float regenerateTime = 5;

    public void MakeInvisible()
    {
        this.gameObject.SetActive(false);
        StartCoroutine(DelayShow());
    }
    IEnumerator DelayShow()
    {
        yield return new WaitForSeconds(regenerateTime);
        this.gameObject.SetActive(true);
    }
}
public enum ItemType
{
    Default,
    /// <summary>
    /// add coins
    /// </summary>
    Coin,
    /// <summary>
    /// add HP
    /// </summary>
    HealthPotion,
    /// <summary>
    /// add game time
    /// </summary>
    TimePotion,
    /// <summary>
    /// reduce HP
    /// </summary>
    ToxicPotion,
    /// <summary>
    /// add score
    /// </summary>
    Score,
}