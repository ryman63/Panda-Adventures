using UnityEngine;

public class Box : DestroyableObject
{
    RarityDestroyableObject Rarity;

    private new void Start()
    {
        base.Start();
        this.TypeDO = TypeDestroyableObject.Box;
    }
    protected override void ChangeTypeAndColor()
    {
        Rarity = RandType();
        Color color = Color.white;
        switch (Rarity)
        {
            case RarityDestroyableObject.Common:
                break;
            case RarityDestroyableObject.Rare:
                color = new Color(0, 0, 255);
                break;
            case RarityDestroyableObject.Epic:
                color = new Color(128, 0, 128);
                break;
            case RarityDestroyableObject.Legendary:
                color = new Color(255, 140, 0);
                break;
            default:
                color = new Color();
                break;
        }
        Body.gameObject.GetComponent<Renderer>().material.color = color;
    }


}
