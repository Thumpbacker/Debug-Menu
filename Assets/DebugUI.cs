using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugUI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI debugText;
    private DebugMenu debugMenu;

    // Start is called before the first frame update
    void Start()
    {
        debugMenu = new DebugMenu();
    }

    // Update is called once per frame
    void Update()
    {
        //Putin update so FPS can update
        debugText.text = debugMenu.DebugInfoText();
    }
}
