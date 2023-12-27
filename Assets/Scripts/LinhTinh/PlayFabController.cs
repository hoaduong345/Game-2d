using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

public class PlayFabController : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField UserNameInput;
    public InputField EmailInput;
    public InputField PasswordInput;
    public Text thongBaoTxt;
    public InputField UserName_lg;
    public InputField Password_lg;

    // hiển thị leaderBoard 2.1
    [Header("PlayFab")]

    //public GameObject nameWindow;
    //public GameObject LeaderboardWindow;
    //public InputField nameInput;
    //public GameObject nameError;

    public GameObject rowPrefab; //dòng chwuas thông tin 1 tên điểm
    public Transform rowsParent; //panel

    // dang ky
    public void dangKy()
    {
        // lay du lieu tu req truyen vao username,email,password
        var req = new RegisterPlayFabUserRequest
        {
            Username = UserNameInput.text,
            Email = EmailInput.text,
            Password = PasswordInput.text,
            DisplayName = UserNameInput.text, // dung de lam bang diem

            RequireBothUsernameAndEmail = false
        };
        // goi API len de thuc hien
        PlayFabClientAPI.RegisterPlayFabUser(req, OnRegisterSucces, OnError);
    }
    public void dangNhap()
    {
        var req = new LoginWithPlayFabRequest
        {
            Username = UserName_lg.text,
            Password = Password_lg.text,
           
        };
        PlayFabClientAPI.LoginWithPlayFab(req, onLoginSuccess, onError_lg);
    }

     void onError_lg(PlayFabError error)
    {
        thongBaoTxt.text = "Login Failed";
        Debug.Log(error);
    }


    void onLoginSuccess(LoginResult result)
    {
        thongBaoTxt.text = "Login Successful";
        Debug.Log("dang nhap thanh cong");
        Sendleaderboard(0);
        //gán tên người chơi để hiển thị lên màn hình
        Shared.tenPlayer = UserName_lg.text;
        // chuyen vao man choi 1
        //   SceneManager.LoadScene("Level 1");
   


    }
    void OnError(PlayFabError error)
    {
        thongBaoTxt.text = error.ToString();
        Debug.Log(error);
    }
    void OnRegisterSucces(RegisterPlayFabUserResult result)
    {

        thongBaoTxt.text = "Register SuccessFul";
        Debug.Log("dang ky thanh cong");
    }
    public void Sendleaderboard(int score)
    {
        var req = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate> { new StatisticUpdate()
            {
                StatisticName="Bangdiem",
                Value=score
            } }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(req, OnLeaderboardupdate, OnError);
    }
    void OnLeaderboardupdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Success");
    }


    public void getLeaderBoardAround()
    {
        var request = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = "Bangdiem",
            MaxResultsCount = 5

        };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, onLeaderboardAroundGet, OnError);
    }
    public void onLeaderboardAroundGet(GetLeaderboardAroundPlayerResult result)
    {
        foreach (Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            if (item.DisplayName != null)
            {
                texts[1].text = item.DisplayName;
            }
            texts[2].text = item.StatValue.ToString();

            Debug.Log(item.Position + " " + item.PlayFabId + item.StatValue);
        }
    }
    //
    public void getLeaderBoard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Bangdiem",
            StartPosition = 0,
            MaxResultsCount = 20

        };
        PlayFabClientAPI.GetLeaderboard(request, onLeaderboardGet, OnError);
    }
    public void onLeaderboardGet(GetLeaderboardResult result)
    {
        foreach (Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName.ToString();
            texts[2].text = item.StatValue.ToString();
            Debug.Log(item.Position + " " + item.PlayFabId + item.StatValue);
        }


    
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Start Scene 1");
    }
    public void GoToLeaderBoard()
    {
        SceneManager.LoadScene("LeaderBoard");
    }

    public void goToSignUP()
    {
        SceneManager.LoadScene("FormScene");
    }
}
