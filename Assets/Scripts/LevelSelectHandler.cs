using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectHandler : MonoBehaviour
{
    [SerializeField] private Button[] _levelButtons;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _levelButtons.Length; i++)
        {
            if (i > PlayerPrefs.GetInt("HighLevel"))
                _levelButtons[i].interactable = false;
        }
    }
}
