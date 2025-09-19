using UnityEngine;


/*
 * <summary>
 * This class is responsible for controlling when a walking animation should start/stop playing
 * </summary>
 * */
public class AnimationStateControler : MonoBehaviour
{
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w")|| Input.GetKey("s")|| Input.GetKey("a")|| Input.GetKey("d"))
        {
            animator.SetBool("IsWalking" ,true);
        }else
        {
            animator.SetBool("IsWalking", false);
        }    
    }
}
