using UnityEngine;

public enum TypeItems { Bamboo, Booster };
public abstract class Item : MonoBehaviour
{
    protected Rigidbody Body;
    protected TypeItems TypeItem;
    public bool IsPickedUp;
    protected delegate void PickUpHandler();
    protected event PickUpHandler PickUpEvent;
    public bool IsGrounded;
   
    protected void Awake()
    {
        Body = GetComponent<Rigidbody>();
        PickUpEvent += PickUp;
    }

    public TypeItems GetTypeItem()
    {
        return TypeItem;
    }

    public Item GetItem()
    {
        return this;
    }

    public void Move(Vector3 DirectionMove, float Speed)
    {
        if(!IsPickedUp)
            this.Body.AddForce(DirectionMove * Speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            PickUpEvent?.Invoke();
        }
        IsGroundedUpdate(collision, true);
    }

    public void PickUp()
    {
        Destroy(GetComponentInParent<Transform>().gameObject);
        IsPickedUp = true;
        switch (TypeItem)
        {
            case TypeItems.Bamboo:
                PlayerCounter.BambooCounter();
                break;
            case TypeItems.Booster:
                PlayerCounter.BoosterCounter();
                break;
        }
    }


    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpdate(collision, false);
    }

    private void IsGroundedUpdate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Item") || collision.gameObject.tag == "Ground")
        {
            IsGrounded = value;
        }
    }

    public void SpawnTo(Vector3 SpawnPoint)
    {
        Vector2 RandomPoint = Random.onUnitSphere * 2;
        int RandRotationX = Random.Range(70, 90);

        int RandRotationY = Random.Range(70, 90);

        int RandRotationZ = Random.Range(70, 90);
        float RandHeight = Random.Range(0f, 1.5f);
        transform.position = SpawnPoint + new Vector3(RandomPoint.x, RandHeight, RandomPoint.y);

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(RandRotationX, RandRotationY, RandRotationZ)), 0.5f);

    }
}

