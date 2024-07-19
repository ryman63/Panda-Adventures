using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    [SerializeField] private Bamboo ItemBamboo;
    [SerializeField] private Booster ItemBooster;
    [SerializeField] private int CountBamboo = 10;
    public void Create(Vector3 DirectionVector)
    {
        int Chance = WeightRandomizer.RandomWeighted(new int[2] { Bamboo.DropChance, Booster.DropChance });
        Vector3 Position = transform.position;
        switch (Chance)
        {
            case (int)TypeItems.Booster:
                {
                    Item Clone = Instantiate(ItemBooster);

                    Clone.SpawnTo(Position);
                }
                break;
            case (int)TypeItems.Bamboo:
                {
                    for (int i = 0; i < CountBamboo; i++)
                    {
                        Item Clone = Instantiate(ItemBamboo);

                        Clone.SpawnTo(Position);

                        Clone.Move(DirectionVector, 3f);
                    }
                }
                break;
        }

        
    }
}
