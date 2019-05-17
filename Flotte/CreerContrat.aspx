<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreerContrat.aspx.cs" Inherits="Flotte.CreerContrat" %>

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
   
   
  <asp:Label ID="Label6" runat="server" Text="Raison Social du Client :"></asp:Label>
            <asp:DropDownList ID="raisonsocialclient" runat="server">
        </asp:DropDownList>
            <asp:Label ID="Erreurraisonsocialclient" runat="server" ForeColor="Red"></asp:Label>
           
   
            <br />
           
   
            <br />
        
   
  <asp:Label ID="Label7" runat="server" Text="Date Effet Debut :"></asp:Label>
            <asp:TextBox ID="dateeffetdebut" runat="server" Height="30px" ></asp:TextBox>
            <asp:Label ID="Erreurdateeffetdebut" runat="server" ForeColor="Red"></asp:Label>
            <script type="text/javascript">
            $(function () {
                var dateFormat = "mm/dd/yy",
                  from = $("#dateeffetdebut")
                    .datepicker({
                        defaultDate: "+1w",
                        changeMonth: true,
                        numberOfMonths: 1
                    })
                    .on("change", function () {
                        to.datepicker("option", "minDate", getDate(this));
                    }),
                  to = $("#dateeffetfin").datepicker({
                      defaultDate: "+1w",
                      changeMonth: true,
                      numberOfMonths: 1 
                  })
                  .on("change", function () {
                      from.datepicker("option", "maxDate", getDate(this));
                  });

                function getDate(element) {
                    var date;
                    try {
                        date = $.datepicker.parseDate(dateFormat, element.value);
                    } catch (error) {
                        date = null;
                    }

                    return date;
                }
            });
</script>
   
            <br />
   
            <br />
   
   
  <asp:Label ID="Label8" runat="server" Text="Date Effet Fin :"></asp:Label>
            <asp:TextBox ID="dateeffetfin" runat="server" Height="24px" ></asp:TextBox>
            <asp:Label ID="Erreurdateffetfin" runat="server" ForeColor="Red"></asp:Label>
            
   
         <br />
            
   
         <br />
            
   
  <asp:Label ID="Label9" runat="server" Text="Agent Responsable :"></asp:Label>
            <asp:DropDownList ID="agentresponsable" runat="server">
        </asp:DropDownList>
            <asp:Label ID="Erreuragentresponsable" runat="server" ForeColor="Red"></asp:Label>
          
   
         <br />
          
   
         <br />
          
   
  <asp:Label ID="Label10" runat="server" Text="Prime Provisoir :"></asp:Label>
            <asp:TextBox ID="primeprovisionnelle" runat="server" Height="24px"></asp:TextBox>
            <asp:Label ID="Erreurprimeprovisoir" runat="server" ForeColor="Red"></asp:Label>
            
            <br />
            
            <br />
            
            <asp:Label ID="SuccesAjout" runat="server" ForeColor="Green"></asp:Label>
          
            <br />
          
            <asp:Label ID="ErreurAjout" runat="server" ForeColor="Red"></asp:Label>
   
            <br />
            <asp:Button ID="Button7" runat="server" OnClick="ajouter" Text="Ajouter"  />
            <asp:Button ID="Button8" runat="server" OnClick="Annuler" Text="Annuler"  />
            <br />
        
    </form>
</body>
</html>
