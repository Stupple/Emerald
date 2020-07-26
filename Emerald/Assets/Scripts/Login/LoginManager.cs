﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Network = EmeraldNetwork.Network;
using C = ClientPackets;

public class LoginManager : MonoBehaviour
{
    //Login
    public GameObject LoginBox;
    public GameObject UserName;
    public GameObject Password;
    //Register
    public GameObject RegisterBox;
    public GameObject RegisterUserName;
    public GameObject RegisterPassword;
    public GameObject ConfirmPassword;
    public GameObject Email;

    private bool loginshown = false;

    // Start is called before the first frame update
    void Start()
    {
        LoginBox.SetActive(false);
        RegisterBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!loginshown && Network.LoginConnected)
            ShowLoginBox();
    }

    public void ShowLoginBox()
    {
        loginshown = true;
        LoginBox.SetActive(true);
        RegisterBox.SetActive(true);
    }

    public void LoginButton_OnClick()
    {
        string username = UserName.GetComponent<TMP_InputField>().text;
        string password = Password.GetComponent<TMP_InputField>().text;

        if (username == string.Empty || password == string.Empty) return;

        Network.Enqueue(new C.Login
        {
            AccountID = username,
            Password = password
        });

        UserName.GetComponent<TMP_InputField>().text = string.Empty;
        Password.GetComponent<TMP_InputField>().text = string.Empty;
    }

    /*public void RegisterButton_OnClick()
    {
        string username = UserName.GetComponent<InputField>().text;
        string email = Email.GetComponent<InputField>().text;
        string password = Password.GetComponent<InputField>().text;
        string confirm = ConfirmPassword.GetComponent<InputField>().text;

        if (username == string.Empty || password == string.Empty) return;
        if (confirm != password) return;

        Network.Enqueue(new C.NewAccount
        {
            AccountID = username,
            Password = password,
            EMailAddress = email,
            BirthDate = DateTime.Now,
            UserName = "na",
            SecretQuestion = "na",
            SecretAnswer = "na"
        });

        UserName.GetComponent<InputField>().text = string.Empty;
        Email.GetComponent<InputField>().text = string.Empty;
        Password.GetComponent<InputField>().text = string.Empty;
        ConfirmPassword.GetComponent<InputField>().text = string.Empty;
    }*/
}
