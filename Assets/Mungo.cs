using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mungo : MonoBehaviour
{
    bool has_won;
    bool is_dead;
    public Animator animation_controller;
    private CharacterController mung_controller;
    private float velocity;

    private float walk_velocity;
    private float run_velocity;
    private float crouch_velocity;
    private float jump_velocty;

    private bool is_jumping;
    private bool is_crouching;

    private float horizVelocity;
    private bool dubJump;

    public GameManager gm;
    public Dictionary<int, int> fruitList;


    // Fields used for inventory
    public UI_Inventory uiInventory;
    private Inventory inventory;
    public MathGame mathGame;
    public Item collidedItem;
    public bool mathGameOpen;              // useful if you want to pause attackers
    public bool isPaused;
    
    // can be level 1,2,3
    public int level = 3;

    public int num_lives;
    public int cswitch;
    public bool jump_sound;

    

    // Start is called before the first frame update
    void Start()
    {
        has_won = false;
        is_dead = false;
        animation_controller = GetComponent<Animator>();
        mung_controller = GetComponent<CharacterController>();

        inventory = new Inventory();
        inventory.level = level;
        uiInventory.SetInventory(inventory);
        num_lives = 3;
        
        is_jumping = false;
        is_crouching = false;
        dubJump = false;

        jump_sound = false;


        walk_velocity = 1.5f;
        crouch_velocity = (float)(walk_velocity/2.0);
        run_velocity = (float)(walk_velocity*2.0);
        jump_velocty = (float)(walk_velocity*3.0);

        mathGameOpen = false;
        isPaused = false;
        Time.timeScale = 1;
        
        //create a dictionary to keep track of which fruits have been collected
        //key is fruit number (1-5) and value is whether it is collected (0 = not collected, 1 = collected)
        fruitList = new Dictionary<int, int>();
        for(int i = 1; i <= 5; i++){
            fruitList.Add(i, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {

        // display the inventory
        if (Input.GetKeyDown("tab") && !mathGameOpen) {
            ShowMungoInventory();
        }

        if(!has_won && !isPaused){

            horizVelocity += (float)(Time.deltaTime * -9.81);

            //fowards
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){

                //crouching fowards
                if(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
                {
                    //Debug.Log("CROUCH FOWARD");
                    animation_controller.SetInteger("state", 4);
                    velocity = velocity < 0.0f ? 0.0f : velocity >= crouch_velocity ? crouch_velocity : velocity + 1f;
                    is_crouching = true;
                }
                //running fowards
                else if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    // //jumping fowards
                    if(Input.GetKey(KeyCode.Space))
                    {
                        //Debug.Log("JUMP FOWARD RUN");
                        horizVelocity = horizVelocity < 0.0f ? 0.0f : horizVelocity >= 10.0f ? 10.0f : horizVelocity + 1f;
                        velocity = velocity < 0.0f ? 0.0f : velocity >= run_velocity ? run_velocity : velocity + 0.05f;
                        animation_controller.SetInteger("state", 3);
                        // if(!jump_sound){
                        //     gm.JumpingSound();
                        //     jump_sound = true;
                        // }
                    }
                    //running fowards
                    else
                    {
                        //Debug.Log("RUN FOWARD");
                        animation_controller.SetInteger("state", 2);
                        velocity = velocity < 0.0f ? 0.0f : velocity >= run_velocity ? run_velocity : velocity + 0.05f;
                    }
                }
                //jumping fowards
                else if(Input.GetKey(KeyCode.Space))
                {
                    //Debug.Log("JUMP FOWARD WALK");
                    horizVelocity = horizVelocity < 0.0f ? 0.0f : horizVelocity >= 10.0f ? 10.0f : horizVelocity + 1f;
                    velocity = velocity < 0.0f ? 0.0f : velocity >= run_velocity ? run_velocity : velocity + 0.05f;
                    animation_controller.SetInteger("state", 3);
                    // if(!jump_sound){
                    //     gm.JumpingSound();
                    //     jump_sound = true;
                    // }
                }
                //walking fowards
                else
                {
                    //Debug.Log("WALK FOWARD");
                    animation_controller.SetInteger("state", 1);
                    velocity = velocity < 0.0f ? 0.0f : velocity >= walk_velocity ? walk_velocity : velocity + 0.01f;
                }
            }
            // backwards
            else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                //crouching backwards
                if(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
                {
                   // Debug.Log("CROUCH BACKWARDS");
                    animation_controller.SetInteger("state", 5);
                    is_crouching = true;
                    float neg_crouch_velocity = ((float)-1 * crouch_velocity);
                    velocity = velocity > 0.0f ? 0.0f : velocity <=  neg_crouch_velocity ? neg_crouch_velocity : velocity - 0.01f; 
                }
                //walking backwards
                else
                {
                    //Debug.Log("WALK BACKWARDS");
                    animation_controller.SetInteger("state", 6);
                    float neg_walk_velocity = ((float)-1 * (float)(walk_velocity / 1.5));
                    velocity = velocity > 0.0f ? 0.0f : velocity <= neg_walk_velocity ? neg_walk_velocity : velocity - 0.01f;  
                }
            }
            else if(Input.GetKey(KeyCode.Space))
            {
                //jumping while moving
                if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    //Debug.Log("THIS IS HALLOWEEN");
                    horizVelocity = horizVelocity < 0.0f ? 0.0f : horizVelocity >= 10.0f ? 10.0f : horizVelocity + 1f;
                    velocity = velocity < 0.0f ? 0.0f : velocity >= run_velocity ? run_velocity : velocity + 0.05f;
                    animation_controller.SetInteger("state", 3);
                    // if(!jump_sound){
                    //     gm.JumpingSound();
                    //     jump_sound = true;
                    // }
                }
                //jumping
                else
                {
                    //Debug.Log("STANDARD JUMP");
                    animation_controller.SetInteger("state", 3);
                    horizVelocity = horizVelocity < 0.0f ? 0.0f : velocity >= 10.0f ? jump_velocty : velocity + 0.05f;
                    if(!jump_sound){
                        gm.JumpingSound();
                        jump_sound = true;
                    }
                }
            }
            //jumps
            else if(Input.GetKey(KeyCode.Space))
            {
                //Debug.Log("JUMP");
                animation_controller.SetInteger("state", 3);
                horizVelocity = horizVelocity < 0.0f ? 0.0f : horizVelocity >= 10.0f ? 10.0f : horizVelocity + 1f;
                // if(!jump_sound){
                //     gm.JumpingSound();
                //     jump_sound = true;
                // }
            }
            //idle
            else
            {
                //Debug.Log("IDLE");
                animation_controller.SetInteger("state", 0);
                velocity = 0.0f;
            }

            //animation_controller.GetInteger("state");

            if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {  
                transform.Rotate(new Vector3(0.0f, -1f, 0.0f));
            }
            else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                transform.Rotate(new Vector3(0.0f, 1f, 0.0f));
            }


            float xdirection = Mathf.Sin(Mathf.Deg2Rad * transform.rotation.eulerAngles.y);
            float zdirection = Mathf.Cos(Mathf.Deg2Rad * transform.rotation.eulerAngles.y);

            //transform.position = new Vector3(transform.position.x + velocity * xdirection * Time.deltaTime, horizVelocity * Time.deltaTime, transform.position.z + velocity * zdirection * Time.deltaTime);


            Vector3 movement_direction = new Vector3(xdirection, 0.0f, zdirection);

            // if(mung_controller.isGrounded){
            //     if(Input.GetKey(KeyCode.Space))
            //     {
            //         horizVelocity = 4;  
            //     }
            // }

            //updating CapsuleCollider based on crouching
            if (is_crouching){
                GetComponent<CapsuleCollider>().center = new Vector3(GetComponent<CapsuleCollider>().center.x, 0.0f, GetComponent<CapsuleCollider>().center.z);
            }
            else{
                GetComponent<CapsuleCollider>().center = new Vector3(GetComponent<CapsuleCollider>().center.x, 0.9f, GetComponent<CapsuleCollider>().center.z);
            }

            // if(!mung_controller.isGrounded && !dubJump){
            //     if(Input.GetKey(KeyCode.Q))
            //     {  
            //         mung_controller.Move(movement_direction * velocity);
            //         dubJump = true;
            //     }
            // }

            movement_direction.x *= Time.deltaTime * velocity;
            movement_direction.y = (float) horizVelocity;
            movement_direction.z *= Time.deltaTime * velocity;
            mung_controller.Move(movement_direction);

        }

    }

    public void PlayMathGame(Item item) {
        Debug.Log("trying to play the math game");
        mathGameOpen = true;
        mathGame.currentItem = item;
        Debug.Log("before reset game");
        mathGame.ResetGame();
        Animator mathAnimator = mathGame.GetComponent<Animator>();
        if(mathAnimator != null) {
            Debug.Log("animator is not null");
            mathAnimator.SetBool("show", true);
        } else {
            Debug.Log("animator is DEF null");
        }
        Time.timeScale = 0;
    }

    public void EndMathGame() {
        Animator mathAnimator = mathGame.GetComponent<Animator>();
        if(mathAnimator != null) {
            mathAnimator.SetBool("show", false);
        }
        Animator animator = uiInventory.GetComponent<Animator>();
        if(animator != null) {
            animator.SetBool("show", true);
        }
        mathGameOpen = false;
    }
    
    public void AddItemToInventory(Item item) {
        gm.PlayMoneySound();
        inventory.AddItem(item);
        uiInventory.RefreshInventoryItems();
        //inventory.AddItem(new Item { itemType = Item.ItemType.PurpleFood, amount = 1, level = level });    
    }

    public void RemoveItemFromInventory(Item item) {
        inventory.RemoveItem(item);
        uiInventory.RefreshInventoryItems();
    }

    public void ShowMungoInventory()  {
        Animator animator = uiInventory.GetComponent<Animator>();
        if(animator != null) {
            bool isShowing = animator.GetBool("show");
            animator.SetBool("show", !isShowing);
            if (isShowing) {
                isPaused = false;
                Time.timeScale = 1;
            } else {
                isPaused = true;
                Time.timeScale = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"collision detected{other.gameObject.name}");
        bool isFood = false;
        switch (other.gameObject.name) {
            default:
                break;
            //case "Apple": 
            case "fruit1":
                collidedItem = new Item { itemType = Item.ItemType.Apple, amount = 1, level=level };
                isFood = true;
                break;
            //case "Eggs": 
            case "fruit2":
                collidedItem = new Item { itemType = Item.ItemType.Eggs, amount = 1, level=level };
                isFood = true;
                break;
            //case "Avacado": 
            case "fruit3":
                collidedItem = new Item { itemType = Item.ItemType.Avacado, amount = 1, level=level };
                isFood = true;
                break;
            case "Cake": 
                collidedItem = new Item { itemType = Item.ItemType.Cake, amount = 1, level=level };
                isFood = true;
                break;
            //case "Purplefood": 
            case "fruit4":
                collidedItem = new Item { itemType = Item.ItemType.PurpleFood, amount = 1, level=level };
                isFood = true;
                break;
            case "Strawberry": 
                collidedItem = new Item { itemType = Item.ItemType.Strawberry, amount = 1, level=level };
                isFood = true;
                break;
        }
        if (isFood) {
            gm.PlayCollectedFruitSound();
            Debug.Log("should play math game");
            PlayMathGame(collidedItem);
            Debug.Log("should destroy other object");
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }

}
