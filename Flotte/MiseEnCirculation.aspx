<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MiseEnCirculation.aspx.cs" Inherits="Flotte.MiseEnCirculation1" %>

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
      <a href="EditerAttestation.aspx">Editer attestation</a>
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
        
       <br />
        <br />
 <fieldset >
     <br />
     <p>
            <asp:Label ID="Label1" runat="server" Text="Numéro du plaque d'immatriculation :"></asp:Label>
            <asp:TextBox ID="numplaque" runat="server"></asp:TextBox>
            <asp:Label ID="ErreurNumPlaque" runat="server" ForeColor="Red"></asp:Label>
     </p>
 
           <p>
            <asp:Label ID="Label10" runat="server" Text="Numéro du contrat associé :"></asp:Label>
            <asp:DropDownList ID="contratassocié" runat="server">
            </asp:DropDownList>
            <asp:Label ID="Erreurcontratasocie" runat="server" ForeColor="Red"></asp:Label>
           </p>
   
         
   <p>
            <asp:Label ID="Label34" runat="server" Text="CIN Assuré :"></asp:Label>
            <asp:DropDownList ID="cinassure" runat="server">
            </asp:DropDownList>
            <asp:Label ID="ErreurCinassure" runat="server" ForeColor="Red"></asp:Label>
   </p>
         
   <p>
            <asp:Label ID="Label16" runat="server" Text="Date validité debut :"></asp:Label>
            <asp:TextBox ID="datevaldebut" runat="server"></asp:TextBox>
            <asp:Label ID="Erreurdatevaldebut" runat="server" ForeColor="Red"></asp:Label>
   </p>
 
   <p>
             <asp:Label ID="Label18" runat="server" Text="Date validité fin :"></asp:Label>
            <asp:TextBox ID="datevalfin" runat="server"></asp:TextBox>
            <asp:Label ID="Erreurdatevalfin" runat="server" ForeColor="Red"></asp:Label>
   </p>
        
           
              <script type="text/javascript">
            $(function () {
                var dateFormat = "mm/dd/yy",
                  from = $("#datevaldebut")
                    .datepicker({
                        defaultDate: "+1w",
                        changeMonth: true,
                        numberOfMonths: 1
                    })
                    .on("change", function () {
                        to.datepicker("option", "minDate", getDate(this));
                    }),
                  to = $("#datevalfin").datepicker({
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
   <p>
            <asp:Label ID="Label19" runat="server" Text="Usage :"></asp:Label>
            <asp:DropDownList ID="usage" runat="server" Height="24px">
            </asp:DropDownList>
            <asp:Label ID="Erreurusage" runat="server" ForeColor="Red"></asp:Label>
   </p>

    <p>
            <asp:Label ID="Label33" runat="server" Text="Classe :"></asp:Label>
            <asp:TextBox ID="classe" runat="server"></asp:TextBox>
            <asp:Label ID="Erreurclasse" runat="server" ForeColor="Red"></asp:Label>
          
   </p>
            
   <p>
            <asp:Label ID="Label21" runat="server" Text="Marque :"></asp:Label>
            <asp:TextBox ID="marque" runat="server"></asp:TextBox>
            <asp:Label ID="Erreurmarque" runat="server" ForeColor="Red"></asp:Label>
   </p>
           
            
   <p>
            <asp:Label ID="Label22" runat="server" Text="Type :"></asp:Label>
            <asp:TextBox ID="type" runat="server" ></asp:TextBox>
            <asp:Label ID="Erreurtype" runat="server" ForeColor="Red"></asp:Label>
   </p>
            
          
   <p>
            <asp:Label ID="Label23" runat="server" Text="Numéro de serie :"></asp:Label>
            <asp:TextBox ID="numserie" runat="server" ></asp:TextBox>
            <asp:Label ID="Erreurnumserie" runat="server" ForeColor="Red"></asp:Label>
   </p>
         
           
   <p>
            <asp:Label ID="Label24" runat="server" Text="Puissance fiscale :"></asp:Label>
            <asp:TextBox ID="puissancefiscale" runat="server"  ></asp:TextBox>
            <asp:Label ID="Erreurpuissancefiscale" runat="server" ForeColor="Red"></asp:Label>
   </p>
 
          
   <p>
            <asp:Label ID="Label25" runat="server" Text="Nombre de place :"></asp:Label>
            <asp:TextBox ID="nbplace" runat="server" ></asp:TextBox>
            <asp:Label ID="Erreurnombreplace" runat="server" ForeColor="Red"></asp:Label>
   </p>

           
   <p>
             <asp:Label ID="Label26" runat="server" Text="Valeur neuf :"></asp:Label>
            <asp:TextBox ID="valeurneuf" runat="server" ></asp:TextBox>
            <asp:Label ID="Erreurvaleurneuf" runat="server" ForeColor="Red"></asp:Label>
   </p>

   <p>
            <asp:Label ID="Label27" runat="server" Text="Valeur venale :"></asp:Label>
            <asp:TextBox ID="valeurvenale" runat="server" ></asp:TextBox>
            <asp:Label ID="Erreurvaleurvenale" runat="server" ForeColor="Red"></asp:Label>
   </p>
 
   <p>
             <asp:Label ID="Label28" runat="server" Text="Poids vide :"></asp:Label>
            <asp:TextBox ID="poidsvide" runat="server" ></asp:TextBox>
            <asp:Label ID="Erreurpoidsvide" runat="server" ForeColor="Red"></asp:Label>
   </p>
 
          
   <p>
            <asp:Label ID="Label29" runat="server" Text="Poids total :"></asp:Label>
            <asp:TextBox ID="poidstotal" runat="server" ></asp:TextBox>
            <asp:Label ID="Erreurpoidstotal" runat="server" ForeColor="Red"></asp:Label>
   </p>
            
   <p>
        <asp:Label ID="Label30" runat="server" Text="Copie Carte Grise :"></asp:Label>
        <asp:Image ID="cartegriseimage" runat="server" Height="54px" ImageAlign="AbsMiddle" Width="150px" />
        <asp:Button ID="Button7" runat="server" OnClick="ChoisirCarteGrise" Text="Choisir" />
   </p>
 
          
  
        <p>
   
  <asp:Label ID="SuccesAjout" runat="server" ForeColor="Green"></asp:Label>
            </p>
        <p>
   
  <asp:Label ID="ErreurAjout" runat="server" ForeColor="Red"></asp:Label>
            </p>
        <p>
            <asp:Button ID="Button2" runat="server" OnClick="verifier" Text="Ajouter" />
            <asp:Button ID="Button3" runat="server" OnClick="Annuler" Text="Annuler" />
        </p>
       </fieldset>
    </form>
</body>
</html>
