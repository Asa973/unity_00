using UnityEngine;

public class test : MonoBehaviour
{
    public Vector3 offset;
    public GameObject target;
    void Start()
    {
        
    }
    void Update()
    {
        if (target == null)
            return;
        transform.position = target.transform.position + offset;
    }
}
