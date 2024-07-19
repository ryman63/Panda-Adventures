using UnityEngine;

public class GameObjectSpawner
{
    private GameObject Cube;
    public GameObjectSpawner(PrimitiveType Type,Transform transform, float Scale)
    {
        Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Cube.transform.position = transform.position;
        Cube.transform.rotation = transform.rotation;
        Cube.transform.localScale = Vector3.one * Scale;
    }

    public GameObject GetSpawn()
        { return Cube; }
  
}
