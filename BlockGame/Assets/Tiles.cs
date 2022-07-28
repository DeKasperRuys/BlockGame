using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tiles : MonoBehaviour
{
    //[SerializeField] public Color Colour1, Colour2, Colour3, Colour4, Colour5;
    [SerializeField] private SpriteRenderer renderer;
    
    [SerializeField] Button btnRed, btnGreen, btnBlue, btnOrange, btnPurple, btnYellow,btnCyan;
    public void Init(int number, Color theColour, Color Red, Color Green, Color Blue, Color Orange, Color Cyan, Color Purple, Color Yellow)
    {

        if (number == 0)
        {

            renderer.color = Red;
        }
        if (number == 1)
        {
            renderer.color = Green;

        }
        if (number == 2)
        {
            renderer.color = Blue;
        }
        if (number == 3)
        {
            renderer.color = Orange;
        }
        if (number == 4)
        {
            renderer.color = Purple;
        }
        if (number == 5)
        {
            renderer.color = Yellow;
        }
        if (number == 6)
        {
            renderer.color = Cyan;
        }




        /*
        if (theColour == Red)
        {
            
            if (number == 0)
            {

                renderer.color = Green;
            }
            if (number == 1)
            {
                renderer.color = Blue;

            }
            if (number == 2)
            {
                renderer.color = Orange;
            }
            if (number == 3)
            {
                renderer.color = Purple;
            }
            if (number == 4)
            {
                renderer.color = Yellow;
            }
            if (number == 5)
            {
                renderer.color = Cyan;
            }
            if (number == 6)
            {
                renderer.color = theColour;
            }
        }
        if (theColour == Green)
        {
            //btnGreen.active =false;
            if (number == 0)
            {

                renderer.color = Red;
            }
            if (number == 1)
            {
                renderer.color = Blue;

            }
            if (number == 2)
            {
                renderer.color = Orange;
            }
            if (number == 3)
            {
                renderer.color = Purple;
            }
            if (number == 4)
            {
                renderer.color = Yellow;
            }
            if (number == 5)
            {
                renderer.color = Cyan;
            }
            if (number == 6)
            {
                renderer.color = theColour;
            }
        }
        if (theColour == Blue)
        {

            if (number == 0)
            {

                renderer.color = Red;
            }
            if (number == 1)
            {
                renderer.color = Green;

            }
            if (number == 2)
            {
                renderer.color = Cyan;
            }
            if (number == 3)
            {
                renderer.color = Orange;
            }
            if (number == 4)
            {
                renderer.color = Purple;
            }
            if (number == 5)
            {
                renderer.color = Yellow;
            }
            if (number == 6)
            {
                renderer.color = theColour;
            }
        }
        if (theColour == Cyan)
        {
            if (number == 0)
            {

                renderer.color = Red;
            }
            if (number == 1)
            {
                renderer.color = Green;

            }
            if (number == 2)
            {
                renderer.color = Blue;
            }
            if (number == 3)
            {
                renderer.color = Orange;
            }
            if (number == 4)
            {
                renderer.color = Purple;
            }
            if (number == 5)
            {
                renderer.color = Yellow;
            }
            if (number == 6)
            {
                renderer.color = theColour;
            }
        }
        if (theColour == Orange)
        {
            if (number == 0)
            {

                renderer.color = Red;
            }
            if (number == 1)
            {
                renderer.color = Green;

            }
            if (number == 2)
            {
                renderer.color = Blue;
            }
            if (number == 3)
            {
                renderer.color = Purple;
            }
            if (number == 4)
            {
                renderer.color = Yellow;
            }
            if (number == 5)
            {
                renderer.color = Cyan;
            }
            if (number == 6)
            {
                renderer.color = theColour;
            }
        }
        if (theColour == Purple)
        {
            if (number == 0)
            {

                renderer.color = Red;
            }
            if (number == 1)
            {
                renderer.color = Green;

            }
            if (number == 2)
            {
                renderer.color = Blue;
            }
            if (number == 3)
            {
                renderer.color = Orange;
            }
            if (number == 4)
            {
                renderer.color = Yellow;
            }
            if (number == 5)
            {
                renderer.color = Cyan;
            }
            if (number == 6)
            {
                renderer.color = theColour;
            }
        }
        if (theColour == Yellow)
        {
            if (number == 0)
            {
                renderer.color = Red;
            }
            if (number == 1)
            {
                renderer.color = Green;

            }
            if (number == 2)
            {
                renderer.color = Blue;
            }
            if (number == 3)
            {
                renderer.color = Orange;
            }
            if (number == 4)
            {
                renderer.color = Purple;
            }
            if (number == 5)
            {
                renderer.color = Cyan;
            }
            if (number == 6)
            {
                renderer.color = theColour;
            }
        }
        */





        /*
        Debug.Log(theColour);
        if (number == 0)
        {

            renderer.color = theColour;
        }
        if (number == 1)
        {
            renderer.color = theColour;

        }
        if (number == 2)
        {
            renderer.color = theColour;
        }
        if (number == 3)
        {
            renderer.color = theColour;
        }
        if (number == 4)
        {
            renderer.color = theColour;
        }
        if (number == 5)
        {
            renderer.color = theColour;
        }
        if (number == 6)
        {
            renderer.color = theColour;
            //renderer.color = new Color(0.8396f, 0.4381f, 0, 1);
        }*/
    }
}
