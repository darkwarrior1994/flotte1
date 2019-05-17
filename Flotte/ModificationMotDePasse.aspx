<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificationMotDePasse.aspx.cs" Inherits="Flotte.ModificationMotDePasse" %>

<!DOCTYPE html>
<html>
<head>
    <title></title>
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
<style>
body {
  font-family: Arial, Helvetica, sans-serif;
}

.navbar {
  overflow: hidden;
  background-color: #333;
}

.navbar a {
  float: left;
  font-size: 16px;
  color: white;
  text-align: center;
  padding: 14px 16px;
  text-decoration: none;
}

.dropdown {
  float: left;
  overflow: hidden;
}

.dropdown .dropbtn {
  font-size: 16px;  
  border: none;
  outline: none;
  color: white;
  padding: 14px 16px;
  background-color: inherit;
  font-family: inherit;
  margin: 0;
}

.navbar a:hover, .dropdown:hover .dropbtn {
  background-color: red;
}

.dropdown-content {
  display: none;
  position: absolute;
  background-color: #f9f9f9;
  min-width: 160px;
  box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
  z-index: 1;
}

.dropdown-content a {
  float: none;
  color: black;
  padding: 12px 16px;
  text-decoration: none;
  display: block;
  text-align: left;
}

.dropdown-content a:hover {
  background-color: #ddd;
}

.dropdown:hover .dropdown-content {
  display: block;
}
</style>
</head>
<body>


    <form id="form2" runat="server">
 
<div class="navbar">
   
 
  <a  href="Redirection.aspx">Acceuil</a>
  
    </div>
  <br />


 <br />
        <fieldset>
    
            <p>
            <asp:Label ID="Label3" runat="server" Text="Mot de passe actuel :"></asp:Label>
                <asp:TextBox ID="ancienmdp" runat="server" TextMode="Password"  ></asp:TextBox>
                <asp:Label ID="Erreurancienmdp" runat="server" ForeColor="Red"></asp:Label>
        </p>
            <p>
            <asp:Label ID="Label6" runat="server" Text="Nouveau Mot de passe :"></asp:Label>
                <asp:TextBox ID="nouveaumdp" runat="server" TextMode="Password" ></asp:TextBox>
                <asp:Label ID="Erreurnouveaumdp" runat="server" ForeColor="Red"></asp:Label>
        </p>
            <p>
            <asp:Label ID="Label10" runat="server" Text="Vérification du nouveau Mot de passe :"></asp:Label>
                <asp:TextBox ID="verificationnouveaumdp" runat="server" TextMode="Password" ></asp:TextBox>
                <asp:Label ID="Erreurvnmdp" runat="server" ForeColor="Red"></asp:Label>
            </p>
            <p>
                <asp:Label ID="Succes" runat="server" ForeColor="Green"></asp:Label>
            </p>
            <p>
                <asp:Label ID="Erreur" runat="server" ForeColor="Red"></asp:Label>
            </p>
            <p>
                <asp:Button ID="Button1" runat="server" OnClick="valider" Text="Valider" Height="26px" />
                <asp:Button ID="Button2" runat="server" OnClick="Annuler" Text="Annuler" Height="26px" />
            </p>
  </fieldset> 


    </form>
    </body>
    </html>
