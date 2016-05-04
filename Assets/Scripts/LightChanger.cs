using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using Random = UnityEngine.Random;

public class LightChanger : MonoBehaviour {

    public Image[] _lights;
    private int _state;
    private float _timeElapsed;
	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("state"))
            _state = PlayerPrefs.GetInt("state");
        else
            _state = 2;
        SwitchLights();       
	}
	
	// Update is called once per frame
	void Update () {
        _timeElapsed += Time.deltaTime;
        if (_timeElapsed >= 2)
            SwitchLights();
	}

    void SwitchLights()
    {
        _timeElapsed = 0;
        Color temp;
        if (Random.Range(0, 3) == 1)
        {            
            //Exit the system and save state
            PlayerPrefs.SetInt("state", _state);
            UnityEditor.EditorApplication.isPlaying = false;
        }
        switch (_state)
        {
            case 0:
                //Red light Enable
                temp = _lights[0].color;
                temp.a = 1.0f;
                _lights[0].color = temp;
                //Green light Disable
                temp = _lights[2].color;
                temp.a = 0.5f;
                _lights[2].color = temp;
                break;
            case 1:
                //Red light Disable
                temp = _lights[0].color;
                temp.a = 0.5f;
                _lights[0].color = temp;
                //Yellow light Enable
                temp = _lights[1].color;
                temp.a = 1.0f;
                _lights[1].color = temp;
                break;
            case 2:
                //Yellow light Disable
                temp = _lights[1].color;
                temp.a = 0.5f;
                _lights[1].color = temp;
                //Green light Enable
                temp = _lights[2].color;
                temp.a = 1.0f;
                _lights[2].color = temp;
                break;
        }
        if (++_state > 2)
            _state = 0;
    }
}
