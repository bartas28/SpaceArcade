using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private GameObject InGameUI;

    [SerializeField]
    private GameObject PauseUI;
    private bool _gamePaused;

    public bool GamePaused
    {
        get { return _gamePaused; }
        set
        {
            _gamePaused = value;
            Time.timeScale = _gamePaused ? 0 : 1;
            PauseUI.SetActive(_gamePaused);
            InGameUI.SetActive(!_gamePaused);
        }
    }

    [SerializeField]
    private Image _musicMutedImage;
    [SerializeField]
    private Image _musicPlayingImage;

    private bool _gameMuted;

    public bool GameMuted
    {
        get { return _gameMuted; }
        set
        {
            _gameMuted = value;
        }
    }


    // Use this for initialization
    void Start () {
        GamePaused = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
