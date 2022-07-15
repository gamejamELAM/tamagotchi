using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student : MonoBehaviour
{
    SpriteRenderer mySpriteRenderer; //A reference to a Sprite Renderer - down below we will link this to the Sprite Renderer attached to this GameObject

    public Sprite studying; //Sprite representing the 'studying' state - we assign this in the Inspector
    public Sprite bored; //Sprite representing the 'bored' state - we assign this in the Inspector
    public Sprite tired; //Sprite representing the 'tired' state - we assign this in the Inspector
    public Sprite giveUp; //Sprite representing the 'given up' state - we assign this in the Inspector

    public float attention = 100f; //Our starting level of attention
    public float lossOfAttention = 10.0f; //How much attention our student loses every time the game updates
    public float attentionThreshold; //How low our attention needs to go before we change state
    public float helpValue = 10.0f; //How much to raise our attention when we help the student

    public float energy = 100f; //Our starting level of energy
    public float lossOfEnergy = 5.0f; //How much energy our student loses every time the game updates
    public float energyThreshold; //How low our energy needs to go before we change state
    public float feedValue = 10.0f; //How much to raise our energy when we help the student

    public float timeBetweenUpdates = 2.0f; //How much time to wait in between updating the game, used as the max value of our timer
    public float timer; //We use this variable to track how much time has passed

    void Start() //This method is called once when the object is loaded
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>(); //Here we use the 'GetComponent' method to link our SpriteRenderer reference to the SpriteRenderer attached to this GameObject
        timer = timeBetweenUpdates; //Set our Timer variable to its max value

        attentionThreshold = attention / 2.0f; //Sets our attention threshold to half of our starting attention
        energyThreshold = energy / 2.0f; //Sets our energy threshold to half of our starting energy
    }

    void Update() //This method is called multiple times a second while our game is running
    {
        timer = timer - Time.deltaTime; //Subtract the amount of time that has passed from our Timer variable

        if(timer < 0) //If our Timer variable is less that 0, run the code in between the curly brackets
        {
            attention = attention - lossOfAttention; //Subtract from our attention
            energy = energy - lossOfEnergy; //Subtract from our energy

            timer = timeBetweenUpdates; //Reset our timer back to its max value
        }

        if ((energy < 0) || (attention < 0)) //If energy is less than zero, OR if attention is less than zero
        {
            mySpriteRenderer.sprite = giveUp; //Set our sprite to the Give Up state
        }
        else if (energy < energyThreshold) //If energy is less than our threshold
        {
            mySpriteRenderer.sprite = tired; //Set our sprite to the Tired state
        }
        else if (attention < attentionThreshold) //If attention is less than our threshold
        {
            mySpriteRenderer.sprite = bored; //Set our sprite to the Bored state
        } 
        else //If none of these other conditions are true
        {
            mySpriteRenderer.sprite = studying; //Set our sprite to the Studying state
        }
    }

    public void Help()
    {
        attention = attention + helpValue;
    }

    public void FeedEnergyDrink()
    {
        energy = energy + feedValue;
    }
}
