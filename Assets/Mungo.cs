using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mungo : MonoBehaviour
{
    bool has_won;
    private CharacterController cc;
    int velocity;
    int walk_velocity;
    private float horizVelocity;
    private bool dubJump;
    public Dictionary<int, int> fruitList;


    // Fields used for inventory
    public UI_Inventory uiInventory;
    private Inventory inventory;
    public MathGame mathGame;
    public Item collidedItem;
    bool mathGameOpen;
    
    // can be level 1,2,3
    public int level = 1;

    

    // Start is called before the first frame update
    void Start()
    {
        has_won = false;
        cc = GetComponent<CharacterController>();
        walk_velocity = 100;
        dubJump = false;

        inventory = new Inventory();
        inventory.level = level;
        uiInventory.SetInventory(inventory);
        
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
        if (Input.GetKeyDown("tab")) {
            ShowMungoInventory();
        }

        if(!has_won){

            horizVelocity += (float)(Time.deltaTime * -9.81);

            if(Input.GetKey(KeyCode.LeftArrow))
            {  
                transform.Rotate(new Vector3(0.0f, -1f, 0.0f));
            }
            else if(Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(new Vector3(0.0f, 1f, 0.0f));
            }

            float xdirection = Mathf.Sin(Mathf.Deg2Rad * transform.rotation.eulerAngles.y);
            float zdirection = Mathf.Cos(Mathf.Deg2Rad * transform.rotation.eulerAngles.y);
            Vector3 movement_direction = new Vector3(xdirection, 0.0f, zdirection);

            if(Input.GetKey(KeyCode.UpArrow))
            {  
                /*
                if(Input.GetKey(KeyCode.Tab)){
                    velocity = walk_velocity;
                }else{
                    velocity = walk_velocity*3;
                }*/

                velocity = walk_velocity*3;
            }
            /*
            else if(Input.GetKey(KeyCode.DownArrow))
            {
                velocity = -100;
            }
            */
            else{
                velocity = 0;
            }

            if(cc.isGrounded){
                horizVelocity = 0f;
                dubJump = false;
                if(Input.GetKey(KeyCode.Space))
                {  
                    horizVelocity = 4;  
                }
            }

            if(!cc.isGrounded && !dubJump){
                if(Input.GetKey(KeyCode.Q))
                {  
                    cc.Move(movement_direction * velocity);
                    dubJump = true;
                }
            }

            movement_direction.y = (float)horizVelocity;

            movement_direction.x *= Time.deltaTime * velocity;
            movement_direction.z *= Time.deltaTime * velocity;
            cc.Move(movement_direction);

        }
    }

        public void PlayMathGame(Item item) {
        mathGameOpen = true;
        mathGame.currentItem = item;
        mathGame.ResetGame();
        Animator mathAnimator = mathGame.GetComponent<Animator>();
        if(mathAnimator != null) {
            mathAnimator.SetBool("show", true);
        }
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
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"collision detected{other.gameObject.name}");
        bool isFood = false;
        switch (other.gameObject.name) {
            default:
            case "Apple": 
                collidedItem = new Item { itemType = Item.ItemType.Apple, amount = 1, level=level };
                isFood = true;
                break;
            case "Eggs": 
                collidedItem = new Item { itemType = Item.ItemType.Eggs, amount = 1, level=level };
                isFood = true;
                break;
            case "Avacado": 
                collidedItem = new Item { itemType = Item.ItemType.Avacado, amount = 1, level=level };
                isFood = true;
                break;
            case "Cake": 
                collidedItem = new Item { itemType = Item.ItemType.Cake, amount = 1, level=level };
                isFood = true;
                break;
            case "Purplefood": 
                collidedItem = new Item { itemType = Item.ItemType.PurpleFood, amount = 1, level=level };
                isFood = true;
                break;
            case "Strawberry": 
                collidedItem = new Item { itemType = Item.ItemType.Strawberry, amount = 1, level=level };
                isFood = true;
                break;
        }
        if (isFood) {
            PlayMathGame(collidedItem);
            Debug.Log("should destroy other object");
            Destroy(other.gameObject);
        }
    }

}
