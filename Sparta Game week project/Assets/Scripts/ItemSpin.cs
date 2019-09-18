using UnityEngine;

public class ItemSpin : MonoBehaviour
{
    public float ySpeed = 0.1f;
    private float posOrNeg;

    private void Start()
    {
        //sets the spin to either left or right
        posOrNeg = Random.Range(0, 2) * 2 - 1;
        
    }

    private void Update()
    {   
        //sets the rotation to the randomly assigned value for a random spin on each object
        transform.Rotate(0, posOrNeg * ySpeed, 0);
    }
}
