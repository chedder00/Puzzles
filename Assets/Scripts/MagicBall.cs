using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MagicBall : MonoBehaviour {

    public string[] _messages;
    public Text _message;
    public Image _image;


    private Vector3 _oldPos;
    private Color _textColor;

    private bool _isDisplaying, _isShaking;
	// Use this for initialization
	void Start () {
        _message.text = "";
        _isDisplaying = false;
        _oldPos = Input.mousePosition;
        _textColor = _message.color;
	}
	
	// Update is called once per frame
	void Update () {
        if (IsMoving()) {
            _image.color = Color.blue;
            if (_isDisplaying) {

                _message.color = new Color(_textColor.r, _textColor.b, _textColor.g, 0.0f);
                _isDisplaying = false;
            }
        }
        else {
            if (!_isDisplaying) {
                _image.color = Color.white;
                _message.text = _messages[Random.Range(0, _messages.Length)];
                _message.color = _textColor;
                _isDisplaying = true;
            }
        }
	}

    private bool IsMoving()
    {
        return Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0;
    }
}
