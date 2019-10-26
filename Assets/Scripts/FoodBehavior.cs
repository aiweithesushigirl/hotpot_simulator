using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class FoodBehavior : MonoBehaviour
{
	public float timeToCook = 30.0f;
	public float optimalTime = 15.0f;
	public float overcookedTime = 35.0f;
	bool grabbed = false;
    private bool alreadyAdded = false;
	public GameObject chopsticks = null;
    public GameObject gameController;
    public GameObject bowl;
    public GameObject slider;
    public OvercookedDisplayer overcooked;
    
    public MeshCollider meshCollider;
    public Behaviour halo;


    float cookedFor = 0.0f;
    int foodState = -1;
    public bool isCooking = false;
    public string foodName;
    public int controlledBy;

    public readonly Dictionary<string, Color> foodColorOptimal = new Dictionary<string, Color>
    {
        { "brocolli", Color.green },
        { "tomato", Color.yellow },
        { "raw_meat", Color.grey },
        { "mushroom", Color.grey },
        { "carrot", Color.grey }
    };
    public readonly Dictionary<string, Color> foodColorOvercook = new Dictionary<string, Color>
    {
        { "brocolli", Color.red },
        { "tomato", Color.black },
        { "raw_meat", Color.black },
        { "mushroom", Color.black },
        { "carrot", Color.black }
    };
    public readonly Dictionary<string, int> foodPoint = new Dictionary<string, int>
    {
        { "brocolli", 1 },
        { "tomato", 1 },
        { "raw_meat", 2 },
        { "mushroom", 1 },
        { "carrot", 1 }
    };

    void Start()
    {
		Debug.Log(this.gameObject);
        gameObject.GetComponent<BrothBuoyancy>().enabled = false;
        halo.enabled = false;
        foodState = -1;
        //slider.transform.position = this.transform.position;
        slider.GetComponent<ProgressBar>().TotalCookingTime = 0f;
        slider.GetComponent<ProgressBar>().healthBar.maxValue = overcookedTime;
        
    }

    void Update()
    {
        var inputDevice = InputManager.ActiveDevice;
        if (grabbed && inputDevice.RightTrigger)
        {

            //GetComponent<Rigidbody>().useGravity = false;
            transform.position = chopsticks.gameObject.GetComponent<Chopsticks>().tip.transform.position;
            //this.gameObject.layer = 9;
            halo.enabled = false;
            //Vector3.MoveTowards(transform.position, chopsticks.gameObject.GetComponent<Chopsticks>().tip.transform.position, 1.0f);
        }
        else
        {
            //this.gameObject.layer = 0;
            GetComponent<Rigidbody>().useGravity = true;

        }

        if (isCooking)
        {

            gameObject.GetComponent<BrothBuoyancy>().enabled = true;
            cookedFor += Time.deltaTime;
            slider.GetComponent<ProgressBar>().TotalCookingTime += Time.deltaTime;
            foodState = 0;
            if (cookedFor >= optimalTime && cookedFor <= timeToCook)
            {
                //gameObject.GetComponent<Renderer>().materials.color = Color.green;
                for (int z = 0; z < gameObject.GetComponent<Renderer>().materials.Length; z++)
                {
                    gameObject.GetComponent<Renderer>().materials[z].color = foodColorOptimal[foodName];
                }
                foodState = 1;
            }

            if (cookedFor > timeToCook)
            {
                for (int z = 0; z < gameObject.GetComponent<Renderer>().materials.Length; z++)
                {
                    gameObject.GetComponent<Renderer>().materials[z].color = foodColorOvercook[foodName];
                }
                gameObject.GetComponent<BrothBuoyancy>().density = 500f;
                foodState = 2;
            }
            if (cookedFor > overcookedTime && !overcooked.GetComponent<OvercookedDisplayer>().isOvercooked)
            {

                for (int z = 0; z < gameObject.GetComponent<Renderer>().materials.Length; z++)
                {
                    gameObject.GetComponent<Renderer>().materials[z].color = Color.black;
                }
                Debug.Log("color" + gameObject.GetComponent<Renderer>().material.color);
                overcooked.GetComponent<OvercookedDisplayer>().isOvercooked = true;               
                gameController.GetComponent<GameController>().DeductPoint(1, controlledBy);
                StartCoroutine(beforeDestroy());
            }
        }
        else
        {
            gameObject.GetComponent<BrothBuoyancy>().enabled = false;
        }


	}

    IEnumerator beforeDestroy()
	{        
        yield return new WaitForSeconds(1.0f);
        overcooked.GetComponent<OvercookedDisplayer>().isOvercooked = false;
        Destroy(this.gameObject);        
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "chopsticks") {
           
            
            Debug.Log("collision" + other.gameObject.tag);
			grabbed = true;
            halo.enabled = true;
            chopsticks = other.gameObject;
            if (!isCooking)
            {
                controlledBy = other.gameObject.GetComponent<Chopsticks>().playerIndex;
            }
            
		}
        else
        {
            meshCollider.isTrigger = false;
        }
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.GetComponent<Chopsticks>()) {
            meshCollider.isTrigger = false;
            grabbed = false;
			chopsticks = null;
            halo.enabled = false;
            
        }
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "bowl" && !alreadyAdded)
        {
            Debug.Log("food state bowl1" + foodState);
            alreadyAdded = true;
            gameController.GetComponent<GameController>().addPoint(foodState, foodPoint[foodName], 1);
            StartCoroutine(eatFood());            
        }
        else if (other.gameObject.tag == "bowl1" && !alreadyAdded)
        {
            Debug.Log("food state bowl2" + foodState);
            alreadyAdded = true;
            gameController.GetComponent<GameController>().addPoint(foodState, foodPoint[foodName], 2);
            StartCoroutine(eatFood());
        }
    }
    IEnumerator eatFood()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        Destroy(slider);
        if (overcooked != null)
        {
            overcooked.GetComponent<OvercookedDisplayer>().isOvercooked = false;
        }
        
    }
}
