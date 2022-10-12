using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CreateRock : MonoBehaviour
{
    public GameObject rock;
    public Animator animator;
    //public Rigidbody rb;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Rock")
        {
            Instantiate(rock, new Vector3(gameObject.transform.position.x + 15 + Random.Range(-5.0f, 5.0f), Random.Range(-3.25f, 0.75f), 0), Quaternion.identity);
            ScoreManager.instance.AddPoint();
        }
        if (collision.gameObject.tag == "Death")
        {
            Debug.Log("Dead");
            animator.SetBool("isDead", true);
            this.GetComponent<CharacterController>().enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
            ScoreManager.instance.EndGame();
            
        }
    }

}
