using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
public class FBManager : MonoBehaviour
{
    private static FBManager instance;
    public static FBManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<FBManager>();
            }
            return instance;
        }
    }
    public const string FailedLevel = "fb_mobile_level_failed";
    public const string StartedLevel = "fb_mobile_level_started";
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance.gameObject);
        }
        else
        {
            if (this != instance)
            {
                Destroy(this.gameObject);
            }
        }
        if (FB.IsInitialized)
        {
            FB.ActivateApp();
        }
        else
        {
            //Handle FB.Init
            FB.Init(() => {
                FB.ActivateApp();
            });
        }
    }
    public void SendEventLevelStarted(int levelID)
    {
        var parameters = new Dictionary<string, object>();
        parameters[AppEventParameterName.Level] = levelID.ToString();
        FB.LogAppEvent(
            StartedLevel, 0f,
            parameters
        );
    }
    public void SendEventLevelCompleted(int levelID)
    {
        var parameters = new Dictionary<string, object>();
        parameters[AppEventParameterName.Level] = levelID.ToString();
        FB.LogAppEvent(
            AppEventName.AchievedLevel, 0f,
            parameters
        );
    }
    public void SendEventLevelFailed(int levelID)
    {
        var parameters = new Dictionary<string, object>();
        parameters[AppEventParameterName.Level] = levelID.ToString();
        FB.LogAppEvent(
            FailedLevel, 0f,
            parameters
        );
    }
}