using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Request
{
    // Start is called before the first frame update
}

public class Register {
    public string roleType {get; set;} 
    public string mobileNo {get; set;}
    public string email {get; set;}
    public string password {get; set;}
    public string name {get; set;}
}

public class Login {
    public string mobileNo{get; set;}
    public string password{get; set;}
}