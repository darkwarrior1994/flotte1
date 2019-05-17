<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Agent.aspx.cs" Inherits="Flotte.Agent" %>

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


    <form id="form2" runat="server">
 
<div class="navbar">
    <div class="dropdown">
    <button class="dropbtn">Risques 
      <i class="fa fa-caret-down"></i>
    </button>
    <div class="dropdown-content">
      <a href="MiseEnCirculation.aspx">Mise en circulation</a>
      <a href="Retrait.aspx">Retrait</a>
         <a href="Risque.aspx">Liste des risques</a>
      
    </div>
  </div> 
    <div class="dropdown">
    <button class="dropbtn">Assurés 
      <i class="fa fa-caret-down"></i>
    </button>
    <div class="dropdown-content">
      <a href="AjouterAssuré.aspx">Ajouter assuré</a>
      <a href="Assurés.aspx">Liste des assurés</a>
      
    </div>
  </div>
     <div class="dropdown">
    <button class="dropbtn">Attestations 
      <i class="fa fa-caret-down"></i>
    </button>
    <div class="dropdown-content">
      <a href="EditerAttestation.aspx">Editer Attestation</a>
      <a href="Attestation.aspx">Liste des attestations</a>
     
      
    </div>
  </div>  
 
  
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



        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="message" runat="server"></asp:Label>
        </p>
    </form>



</body>
</html>
