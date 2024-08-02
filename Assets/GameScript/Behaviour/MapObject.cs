using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject : MonoBehaviour
{
    public MapObjectType objTpye = MapObjectType.DEFAULT;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
public enum MapObjectType
{
    DEFAULT = 0,
    GOLD_COIN = 1,
    RED_POTION = 2,
    TOXIC_POTION = 3,
    TIME_POTION = 4,
    STAR = 5,
}
