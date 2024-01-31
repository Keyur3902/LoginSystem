using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.SceneManagement;

public class NetworkingManager : MonoBehaviour
{
    public static NetworkingManager instance;
    public string baseUrl = "https://parking-eb51.onrender.com/user/";
    // public string baseUrl = "https://shopping-app-backend-t4ay.onrender.com/user/";

    //Register
    public TMP_InputField emailInputField;
    public TMP_InputField passwordInputField;
    public TMP_InputField confirmPasswordInputField;
    public TMP_InputField loginEmailInputField;
    public TMP_InputField loginPasswordInputField;
    public GameObject loginPanel;
    public GameObject registerPanel;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRegButton() {
        Register register = new Register() {name = "abc", email = emailInputField.text, password = passwordInputField.text, mobileNo = "1212121217", roleType = "1"};
        StartCoroutine(Register(register));
    }

    public void OnLogInButton() {
        Login login = new Login() {mobileNo = loginEmailInputField.text, password = loginPasswordInputField.text};
        StartCoroutine(Login(login));
    }

    public IEnumerator Register(Register register)
    {
        Debug.Log(register);

        using (UnityWebRequest uwr = new UnityWebRequest("https://parking-eb51.onrender.com/user/register", "POST"))
        {
            WWWForm form = new WWWForm();
            form.AddField("email", register.email);
            form.AddField("password", register.password);
            form.AddField("mobileNo", register.mobileNo);
            form.AddField("roleType", register.roleType);
            form.AddField("name", register.name);

            uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(form.data);
            uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

            uwr.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");

            yield return uwr.SendWebRequest();

            if (uwr.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("Error: " + uwr.error);
            }
            else
            {
                Debug.Log(uwr.downloadHandler.text);
                registerPanel.SetActive(false);
                loginPanel.SetActive(true);
                
            }
        }
    }

    public IEnumerator Login(Login login)
    {
        Debug.Log(login);

        using (UnityWebRequest uwr = new UnityWebRequest("https://parking-eb51.onrender.com/user/login", "POST"))
        {
            WWWForm form = new WWWForm();
            // form.AddField("email", login.email);
            form.AddField("password", login.password);
            form.AddField("mobileNo", login.mobileNo);
            // form.AddField("roleType", register.roleType);
            // form.AddField("name", register.name);

            uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(form.data);
            uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

            uwr.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");

            yield return uwr.SendWebRequest();

            if (uwr.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log("Error: " + uwr.error);
            }
            else
            {
                Debug.Log(uwr.downloadHandler.text);
                SceneManager.LoadScene("Prototype 1");
            }
        }
    }

}
