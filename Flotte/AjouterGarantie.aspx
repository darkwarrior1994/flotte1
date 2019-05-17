<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjouterGarantie.aspx.cs" Inherits="Flotte.AjouterGarantie" %>
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
    <button class="dropbtn">Utilisateurs 
      <i class="fa fa-caret-down"></i>
    </button>
    <div class="dropdown-content">
      <a href="AjouterUtilisateur.aspx">Ajouter Utilisateur</a>
      <a href="ListeUtilisateurs.aspx">Liste des Utilisateurs</a>
     </div>
      </div> 
   
  <div class="dropdown">
    <button class="dropbtn">Usages 
      <i class="fa fa-caret-down"></i>
    </button>
    <div class="dropdown-content">
      <a href="AjouterUsage.aspx">Ajouter Usage</a>
      <a href="ListeUsages.aspx">Liste des Usages</a>
      
   </div>
      </div>
    <div class="dropdown">
    <button class="dropbtn">Garanties 
      <i class="fa fa-caret-down"></i>
    </button>
    <div class="dropdown-content">
      <a href="AjouterGarantie">Ajouter Garantie</a>
      <a href="ListeGaranties.aspx">Liste des Garanties</a>
      
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
        <fieldset>
            <p>
                <asp:Label ID="Label2" runat="server" Text="Libelle Garantie :"></asp:Label>
                <asp:TextBox ID="libellegarantie" runat="server"></asp:TextBox>
                <asp:Label ID="Erreurlibellegarantie" runat="server" ForeColor="Red"></asp:Label>
            </p>
                <p>
                    <asp:Label ID="Label1" runat="server" Text="Id :"></asp:Label>
                    <asp:TextBox ID="idgarantie" runat="server"></asp:TextBox>
            <asp:Label ID="Erreuridgarantie" runat="server" ForeColor="Red"></asp:Label>
           
               </p>
           
           <p>
               <asp:Label ID="SuccesAjout" runat="server" ForeColor="Green"></asp:Label>
           </p> 
            
           <p>
                <asp:Label ID="ErreurAjout" runat="server" ForeColor="Red"></asp:Label>
           </p>
   
           
            <p>
             <asp:Button ID="Button7" runat="server" OnClick="Ajouter" Text="Ajouter" />
            <asp:Button ID="Button8" runat="server" OnClick="Annuler" Text="Annuler" />
            </p>
          
  </fieldset>
    
    </form>
</body>
</html>
