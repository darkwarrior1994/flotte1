<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjouterClient.aspx.cs" Inherits="Flotte.AjouterClient" %>

<!DOCTYPE html>
<html>
<head>
    <title></title>
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
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

    <form id="form1" runat="server">       
<div class="navbar">
   <div class="dropdown">
    <button class="dropbtn">Contrats 
      <i class="fa fa-caret-down"></i>
    </button>
    <div class="dropdown-content">
      <a href="CreerContrat.aspx">Créer Contrat</a>
      <a href="Contrats.aspx">Liste des contrats</a>
        
    </div>
  </div> 
     <div class="dropdown">
    <button class="dropbtn">Clients 
      <i class="fa fa-caret-down"></i>
    </button>
    <div class="dropdown-content">
      <a href="AjouterClient.aspx">Ajouter Client</a>
      <a href="Clients.aspx">Liste des clients</a>
        
    </div>
  </div> 
  <a  href="Attestation.aspx">Quittances</a>
     <a  href="Historique.aspx">Historique</a>
  <div class="dropdown">
    <button class="dropbtn">Consultation 
      <i class="fa fa-caret-down"></i>
    </button>
    <div class="dropdown-content">
      <a href="CParcs.aspx">Parcs</a>
      <a href="CRisque.aspx">Risques</a>
      <a href="#">Attestations</a>
      <a href="#">Termes</a>
      <a href="#">Liquidation</a>
      
    </div>
  </div> 
  <div class="dropdown">
    <button class="dropbtn">Parametre 
      <i class="fa fa-caret-down"></i>
    </button>
    <div class="dropdown-content">
      <a href="Deconnexion.aspx">Deconnexion</a>
      <a href="ModificationMotDePasse.aspx">Modifier mot de passe</a>
      
    </div>
  </div> 
</div>
          <br />
   
              <br />
   
            <br />
            <br />
        <fieldset>
   
  <asp:Label ID="Label3" runat="server" Text="Raison social :"></asp:Label>
            <asp:TextBox ID="raisonsocial" runat="server"></asp:TextBox>
            <asp:Label ID="Erreurraisonsocial" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
   
  <asp:Label ID="Label4" runat="server" Text="Adresse :"></asp:Label>
            <asp:TextBox ID="adresse" runat="server" ></asp:TextBox>
            <asp:Label ID="Erreuradresse" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
   
  <asp:Label ID="Label5" runat="server" Text="Telephone :"></asp:Label>
            <asp:TextBox ID="tel" runat="server"></asp:TextBox>
            <asp:Label ID="Erreurtel" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
   
  <asp:Label ID="Label6" runat="server" Text="Fax :"></asp:Label>
            <asp:TextBox ID="fax" runat="server"></asp:TextBox>
            <asp:Label ID="Erreurfax" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
   
  <asp:Label ID="Label7" runat="server" Text="Ville :"></asp:Label>
            <asp:DropDownList ID="ville" runat="server"  Height="30px" Width="99px" AutoPostBack="True" OnSelectedIndexChanged="gouvernoratselectioné"   >
            </asp:DropDownList>
            <asp:Label ID="Erreurville" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
   
  <asp:Label ID="Label8" runat="server" Text="Gouvernorat :"></asp:Label>
            <asp:DropDownList ID="gouvernorat" runat="server" Height="30px" >
            </asp:DropDownList>
            <asp:Label ID="Erreurgouvernorat" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
   
  <asp:Label ID="Label9" runat="server" Text="Code Postal :"></asp:Label>
            <asp:TextBox ID="codepostal" runat="server"></asp:TextBox>
            <asp:Label ID="Erreurcodepostal" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <br />
   
            <br />
            <br />
            <asp:Label ID="SuccesAjout" runat="server" ForeColor="Green"></asp:Label>
            <br />
            <br />
            <asp:Label ID="ErreurAjout" runat="server" ForeColor="Red"></asp:Label>
   
            <br />
            <br />
            <asp:Button ID="Ajouter" runat="server" OnClick="ajouter" Text="Ajouter"  />
            <asp:Button ID="Annuler" runat="server" OnClick="annuler" Text="Annuler" />
            <br />
   
          <br />

    </fieldset>
    </form>
</body>
</html>
