<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AffecterGarantie.aspx.cs" Inherits="Flotte.AffecterGarantie" %>

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
    <fieldset>
        <div class="navbar">
 <a  href="Risque.aspx">Risque</a>
  <a  href="Attestation.aspx">Attestations</a>
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
      <a href="#">Deconnexion</a>
      <a href="ModificationMotDePasse.aspx">Modification mot passe</a>
      
    </div>
  </div> 
</div>


        <br />


 <br />
        <fieldset>
    
   <p>
            <asp:Label ID="Label1" runat="server" Text="Numéro du plaque d'immatriculation :"></asp:Label>
            <asp:TextBox ID="numplaque" runat="server"></asp:TextBox>
        </p>
            <p>
                <asp:Label ID="ErreurNumPlaque" runat="server"></asp:Label>
        </p>
            <p>
            <asp:Label ID="Label2" runat="server" Text="Numéro du contrat asoocié :"></asp:Label>
                <asp:TextBox ID="numcontrat" runat="server"></asp:TextBox>
        </p>
            <p>
                <asp:Label ID="ErreurNumContrat" runat="server"></asp:Label>
        </p>
            <p>
            <asp:Label ID="Label3" runat="server" Text="Ordre du risque :"></asp:Label>
                <asp:TextBox ID="ordrer" runat="server" ></asp:TextBox>
        </p>
            <p>
                <asp:Label ID="ErreurOrdreRisque" runat="server"></asp:Label>
        </p>
            <p>
            <asp:Label ID="Label4" runat="server" Text="Etat du risque :"></asp:Label>
                <asp:DropDownList ID="etatr" runat="server" Height="24px">
                    <asp:ListItem>C</asp:ListItem>
                    <asp:ListItem>R</asp:ListItem>
                </asp:DropDownList>
        </p>
            <p>
            <asp:Label ID="Label5" runat="server" Text="Etat du contrat :"></asp:Label>
                <asp:DropDownList ID="etatc" runat="server" Height="24px">
                    <asp:ListItem>C</asp:ListItem>
                    <asp:ListItem>T</asp:ListItem>
                </asp:DropDownList>
        </p>
            <p>
            <asp:Label ID="Label6" runat="server" Text="Ordre du contrat :"></asp:Label>
                <asp:TextBox ID="ordrec" runat="server" ></asp:TextBox>
        </p>
            <p>
                <asp:Label ID="ErreurOrdreContrat" runat="server"></asp:Label>
            </p>
            <p>
            <asp:Label ID="Label7" runat="server" Text="Intermediaire :"></asp:Label>
                <asp:TextBox ID="intermediaire" runat="server" ></asp:TextBox>
            </p>
            <p>
            <asp:Label ID="Label8" runat="server" Text="Garantie Legale :"></asp:Label>
                <asp:DropDownList ID="RC" runat="server" Height="26px">
                    <asp:ListItem>RC</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
            <asp:Label ID="Label9" runat="server" Text="Grarantie Contractuelle :"></asp:Label>
                <asp:DropDownList ID="INCENDIE" runat="server" Height="26px">
                    <asp:ListItem>INCENDIE</asp:ListItem>
                    <asp:ListItem Selected="True">Non</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
            <asp:Label ID="Label10" runat="server" Text="Grarantie Contractuelle :"></asp:Label>
                <asp:DropDownList ID="VOL" runat="server" Height="26px">
                    <asp:ListItem Selected="True">Non</asp:ListItem>
                    <asp:ListItem>VOL</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
            <asp:Label ID="Label11" runat="server" Text="Grarantie Contractuelle :"></asp:Label>
                <asp:DropDownList ID="CAS" runat="server" Height="26px">
                    <asp:ListItem Selected="True">Non</asp:ListItem>
                    <asp:ListItem>CAS</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
            <asp:Label ID="Label12" runat="server" Text="Grarantie Contractuelle :"></asp:Label>
                <asp:DropDownList ID="TIERCESANSFRANCHISE" runat="server" Height="26px">
                    <asp:ListItem Selected="True">Non</asp:ListItem>
                    <asp:ListItem>TIERCE SANS FRANCHISE</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
            <asp:Label ID="Label13" runat="server" Text="Grarantie Contractuelle :"></asp:Label>
                <asp:DropDownList ID="TIERCEAVECFRANCHISE" runat="server" Height="26px">
                    <asp:ListItem Selected="True">Non</asp:ListItem>
                    <asp:ListItem>TIERCE AVEC FRANCHISE</asp:ListItem>
                </asp:DropDownList>
            <asp:Label ID="Label14" runat="server" Text="Pourcentage :"></asp:Label>
                <asp:DropDownList ID="poucentage" runat="server" Height="26px">
                    <asp:ListItem Selected="True">Non</asp:ListItem>
                    <asp:ListItem>1%</asp:ListItem>
                    <asp:ListItem>2%</asp:ListItem>
                    <asp:ListItem>4%</asp:ListItem>
                    <asp:ListItem>8%</asp:ListItem>
                    <asp:ListItem>12%</asp:ListItem>
                    <asp:ListItem>16%</asp:ListItem>
                    <asp:ListItem>20%</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p>
                <asp:Label ID="Succes" runat="server" ForeColor="Green"></asp:Label>
            </p>
            <p>
   
  <asp:Label ID="Erreur" runat="server" ForeColor="Red"></asp:Label>
            </p>
            <p>
                <asp:Button ID="Button1" runat="server"  Text="Calculer" Height="26px" OnClick="Calculer" />
                <asp:Button ID="Button2" runat="server"  Text="Annuler" Height="26px" />
            </p>

    </fieldset>
    
    
    </form>
</body>
</html>
