using UnityEngine;

public class Bamboo : Item
{
    public static int DropChance = 95;

    private new void Awake()
    {
        base.Awake();
        this.TypeItem = TypeItems.Bamboo;

    }

 
}
