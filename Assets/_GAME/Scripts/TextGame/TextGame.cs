using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Ambrosia.EventBus;

public class TextGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI mainText;
    [SerializeField] private TextMeshProUGUI yesText;
    [SerializeField] private TextMeshProUGUI noText;
    [SerializeField] private GameObject dieText;
    private string _mainString = "";
    private string _yesString = "";
    private string _noString = "";

    private int _index = 0;
    private bool _text1Active = true;
    private bool _text2Active = true;
    private bool _text3Active = true;
    private bool _text4Active = true;
    private bool _dieActive = false;

    private void Update()
    {
        //Yes text
        if (Input.GetKey(KeyCode.A) && _index == 0 && _text1Active)
        {
            _mainString =
                "You continue down the dark and narrow path. After a few minutes, you hear the sound of rushing water. As you approach, you see a small waterfall and a pool of crystal clear water.";
            _yesString = "Take a drink from the waterfall";
            _noString = "Dive in the pool";
            _index = 1;
            StartCoroutine(WaitAndPrintYes(1, _yesString, _noString, _mainString));
            _text1Active = false;
        }

        //No text
        else if (Input.GetKey(KeyCode.B) && _index == 0 && _text2Active)
        {
            dieText.SetActive(true);
            _dieActive = true;
            _text2Active = false;
            _text1Active = true;
            _mainString = " ";
            _yesString = " ";
            _noString = " ";
            StartCoroutine(WaitAndPrintNo(0, _noString, _yesString, _mainString));
            //Başa dön
            // _mainString =
            //     "You are a adventurer traveling through a dense jungle in search of a lost temple. You have a map, a backpack, and a machete.As you walk, you come to a fork in the road. To the left is a dark and narrow path, to the right is a wider path with lighter vegetation.Which path do you take?";
            // _yesString = "Take the dark and narrow path";
            // _noString = "Take the wider path with lighter vegetation";
            // _index = 0;
            // StartCoroutine(WaitAndPrintNo(1, _yesString, _noString, _mainString));
            _text1Active = true;
            _text2Active = false;
        }

        //Yes text 2
        else if (Input.GetKey(KeyCode.Alpha1) && _index == 1 && _text3Active)
        {
            //Stick manli oyun
            _mainString = "You dive in the pool";
            mainText.text = _mainString;
            _text3Active = false;
            EventBus<PlayStickmanStateEvent>.Emit(this, new PlayStickmanStateEvent());
        }

        //No text 2
        else if (Input.GetKey(KeyCode.Alpha2) && _index == 1 && _text4Active)
        {
            dieText.SetActive(true);
            _dieActive = true;
            _text4Active = false;
            _text1Active = true;
            _mainString = " ";
            _yesString = " ";
            _noString = " ";
            StartCoroutine(WaitAndPrintNo(0, _noString, _yesString, _mainString));
            //en başa dön
            // _mainString =
            //     "You are a adventurer traveling through a dense jungle in search of a lost temple. You have a map, a backpack, and a machete.As you walk, you come to a fork in the road. To the left is a dark and narrow path, to the right is a wider path with lighter vegetation.Which path do you take?";
            // _yesString = "Take the dark and narrow path";
            // _noString = "Take the wider path with lighter vegetation";
            // _index = 0;
            // _text1Active = true;
            // _text4Active = false;
            // StartCoroutine(WaitAndPrintNo(1, _noString, _yesString, _mainString));
        }

        if (Input.GetKey(KeyCode.Space))
        {
            dieText.SetActive(false);
            _dieActive = false;
        }

        if (_dieActive)
        {
            _mainString =
                "You are a adventurer traveling through a dense jungle in search of a lost temple. You have a map, a backpack, and a machete.As you walk, you come to a fork in the road. To the left is a dark and narrow path, to the right is a wider path with lighter vegetation.Which path do you take?";
            _yesString = "Take the dark and narrow path";
            _noString = "Take the wider path with lighter vegetation";
            _index = 0;
            _text1Active = true;
            _text4Active = false;
            StartCoroutine(WaitAndPrintNo(1, _noString, _yesString, _mainString));
        }
    }


    IEnumerator WaitAndPrintYes(float waitTime, string textYes, string textNo, string mainYes)
    {
        yield return new WaitForSeconds(waitTime);
        mainText.text = mainYes;
        _yesString = textYes;
        _noString = textNo;
        yesText.text = _yesString;
        noText.text = _noString;
    }

    IEnumerator WaitAndPrintNo(float waitTime, string textYes, string textNo, string mainNo)
    {
        yield return new WaitForSeconds(waitTime);
        mainText.text = mainNo;
        _yesString = textYes;
        _noString = textNo;
        noText.text = _noString;
        yesText.text = _yesString;
    }
}