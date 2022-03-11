using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class GPGSManager : MonoBehaviour
{
    private PlayGamesClientConfiguration clientConfiguration;
    //public Text statusText;

    internal void ConfigureGPGS(){
        clientConfiguration = new PlayGamesClientConfiguration.Builder().Build();

    }

    private void Start() {
        ConfigureGPGS();
        SignIntoGPGS(SignInInteractivity.CanPromptOnce,clientConfiguration);
    }

    internal void SignIntoGPGS(SignInInteractivity interactivity, PlayGamesClientConfiguration configuration)
    {
        configuration = clientConfiguration;
        PlayGamesPlatform.InitializeInstance(configuration);
        PlayGamesPlatform.Activate();

        PlayGamesPlatform.Instance.Authenticate(interactivity, (code) => 
        {
            if(code ==SignInStatus.Success)
            {
                //Sucessfully AUthenticated
            }
            else
            {
                //Authentican failed
            }
        });
    }

    public void BasicSignInBtn()
    {
        SignIntoGPGS(SignInInteractivity.CanPromptAlways,clientConfiguration);
    }

    public void SignOut(){
        PlayGamesPlatform.Instance.SignOut();
    }
}
