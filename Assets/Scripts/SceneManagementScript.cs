using UnityEngine;

[RequireComponent(typeof(DialogManager))]
public class SceneManagementScript : MonoBehaviour
{
    public bool canUseBed = true;
    public bool canUseKitchen = true;
    public bool canUseExit = true;
    public bool canUsePhone = true;
    public bool isPCSwitchOn = false;
    public bool isTelephoneRinging = false;

    public bool hasGlitched = false;
    public bool hasTreeStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
