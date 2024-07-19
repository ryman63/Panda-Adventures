using System;
using System.Collections.Generic;
using UnityEngine;

public enum TypeDestroyableObject { Barell, Box};
public abstract class DestroyableObject : MonoBehaviour
{
    protected bool IsDestroyed;
    protected Rigidbody Body;
    protected delegate void DestroyHandler();
    protected event DestroyHandler DestroyEvent;
    public TypeDestroyableObject TypeDO;
    protected enum RarityDestroyableObject { Common = 1, Rare = 2, Epic = 3, Legendary = 4 }
    protected enum RarityChanceDO { Common = 50, Rare = 39, Epic = 10, Legendary = 1}
    private GameObject Collision;
    protected void Start()
    {
        DestroyEvent += Destroy;
        DestroyEvent += InstantiateItems;
        Body = GetComponent<Rigidbody>();
        ChangeTypeAndColor();
    }
    void Update()
    {

    }
    protected abstract void ChangeTypeAndColor();
    protected Transform GetTransform()
    {
        if (!IsDestroyed)
            return Body.transform;
        else return null;
    }
    protected void MoveObject(Vector3 DirectionMove, float Speed)
    {
        if (!IsDestroyed)
        {
            this.Body.AddForce(DirectionMove * Speed);
        }
    }
    protected RarityDestroyableObject RandType()
    {
        int ChanceRarity = WeightRandomizer.RandomWeighted(new int[4] { 
                                                            (int)RarityChanceDO.Common, 
                                                            (int)RarityChanceDO.Rare, 
                                                            (int)RarityChanceDO.Epic,
                                                            (int)RarityChanceDO.Legendary });
        switch (ChanceRarity)
        {
            case 0:
                return RarityDestroyableObject.Common;
            case 1:
                return RarityDestroyableObject.Rare;
            case 2:
                return RarityDestroyableObject.Epic;
            case 3:
                return RarityDestroyableObject.Legendary;
                default: return RarityDestroyableObject.Common;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("PlayerInSprint"))
        {
            Collision = collision.gameObject;
            DestroyEvent?.Invoke();
        }
        
    }
    protected void InstantiateItems()
    {
        Vector3 DirectionVector = Collision.GetComponent<ThirdPersonMovement>().InputVector;
        GetComponent<ItemFactory>().Create(DirectionVector);
    }
    protected void Destroy()
    {
        Destroy(this.gameObject);
        IsDestroyed = true;
    }
}
