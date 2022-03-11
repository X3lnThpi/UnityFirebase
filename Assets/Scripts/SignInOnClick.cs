using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using Firebase.Auth;

public class SignInOnClick : MonoBehaviour {

 // Use this for initialization
 void Start () {
  // Initialize Play Games Configuration and Activate it.
  PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
   .RequestServerAuthCode(false /*forceRefresh*/)
   // enables saving game progress.
        .EnableSavedGames()
        // requests the email address of the player be available.
        // Will bring up a prompt for consent.
        .RequestEmail()
        // requests a server auth code be generated so it can be passed to an
        //  associated back end server application and exchanged for an OAuth token.
        .RequestServerAuthCode(false)
        // requests an ID token be generated.  This OAuth token can be used to
        //  identify the player to other services such as Firebase.
        .RequestIdToken()
        .Build();
  PlayGamesPlatform.InitializeInstance(config);
  PlayGamesPlatform.Activate ();
  Debug.LogFormat ("SignInOnClick: Play Games Configuration initialized");
 }


 public void SignInWithPlayGames () {
     
  // Initialize Firebase Auth
  Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

  // Sign In and Get a server auth code.
  UnityEngine.Social.localUser.Authenticate ((bool success) => {
   if (!success) {
    Debug.LogError ("SignInOnClick: Failed to Sign into Play Games Services.");
    return;
   }

   string authCode = PlayGamesPlatform.Instance.GetServerAuthCode ();
   if (string.IsNullOrEmpty (authCode)) {
    Debug.LogError ("SignInOnClick: Signed into Play Games Services but failed to get the server auth code.");
    return;
   }
   Debug.LogFormat ("SignInOnClick: Auth code is: {0}", authCode);

   // Use Server Auth Code to make a credential
   Firebase.Auth.Credential credential = Firebase.Auth.PlayGamesAuthProvider.GetCredential(authCode);

   // Sign In to Firebase with the credential
   auth.SignInWithCredentialAsync(credential).ContinueWith(task => {
    if (task.IsCanceled) {
     Debug.LogError ("SignInOnClick was canceled.");
     return;
    }
    if (task.IsFaulted) {
     Debug.LogError ("SignInOnClick encountered an error: " + task.Exception);
     return;
    }

    Firebase.Auth.FirebaseUser newUser = task.Result;
    ((GooglePlayGames.PlayGamesPlatform)Social.Active).SetGravityForPopups(Gravity.BOTTOM);
    Debug.LogFormat ("SignInOnClick: User signed in successfully: {0} ({1})", newUser.DisplayName, newUser.UserId);
   });


///My added
Firebase.Auth.FirebaseUser user = auth.CurrentUser;
if (user != null) {
  string playerName = user.DisplayName;

  // The user's Id, unique to the Firebase project.
  // Do NOT use this value to authenticate with your backend server, if you
  // have one; use User.TokenAsync() instead.
  string uid = user.UserId;
}
  });
 }
}