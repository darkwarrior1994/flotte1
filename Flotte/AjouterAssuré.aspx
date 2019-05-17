<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjouterAssuré.aspx.cs" Inherits="Flotte.AjouterAssuré" %>
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

    
    <div>
    
        <br />
    
        <br />
    
    </div>
        <fieldset style="height: 405px">
 <p>
       <asp:Label ID="Label2" runat="server" Text="CIN :"></asp:Label>
       <asp:TextBox ID="cin" runat="server"></asp:TextBox>
       <asp:Label ID="ErreurCin" runat="server" ForeColor="Red"></asp:Label>
 </p>
     <p>
           <asp:Label ID="Label3" runat="server" Text="Nom :"></asp:Label>
           <asp:TextBox ID="nom" runat="server"></asp:TextBox>
           <asp:Label ID="Erreurnom" runat="server" ForeColor="Red"></asp:Label>
    </p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Prenom :"></asp:Label>
            <asp:TextBox ID="prenom" runat="server" ></asp:TextBox>
            <asp:Label ID="Erreurprenom" runat="server" ForeColor="Red"></asp:Label>
        </p>
            <p>
                 <asp:Label ID="Label5" runat="server" Text="Adresse :"></asp:Label>
                 <asp:TextBox ID="adresse" runat="server"></asp:TextBox>
                 <asp:Label ID="Erreuradresse" runat="server" ForeColor="Red"></asp:Label>
            </p>
             <p>
                 <asp:Label ID="Label6" runat="server" Text="Telephone :"></asp:Label>
                 <asp:TextBox ID="tel" runat="server"></asp:TextBox>
                 <asp:Label ID="Erreurtel" runat="server" ForeColor="Red"></asp:Label>
            </p>
            <p>
                  <asp:Label ID="Label7" runat="server" Text="Ville :"></asp:Label>
                  <asp:DropDownList ID="ville" runat="server"  Height="30px" Width="99px" AutoPostBack="True" OnSelectedIndexChanged="gouvernoratselectioné"   >
                  </asp:DropDownList>
            </p>
            <p>
                 <asp:Label ID="Label8" runat="server" Text="Gouvernorat :"></asp:Label>
                 <asp:DropDownList ID="gouvernorat" runat="server" Height="30px" >
                 </asp:DropDownList>
            </p>
            <p>
                 <asp:Label ID="Label9" runat="server" Text="Code Postal :"></asp:Label>
                 <asp:TextBox ID="codepostal" runat="server"></asp:TextBox>
                 <asp:Label ID="Erreurcodepostal" runat="server" ForeColor="Red"></asp:Label>
            </p>
            <p>
                 <asp:Label ID="Label34" runat="server" Text="Cpoie CIN :"></asp:Label>
                 <asp:Image ID="Image5" runat="server" Height="54px" ImageAlign="AbsMiddle" Width="150px" />
                 <asp:Button ID="Button6" runat="server" OnClick="choisircin" Text="Choisir"  />
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
