<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Risque.aspx.cs" Inherits="Flotte.MiseEnCirculation" %>

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
         
        <p>
            &nbsp;</p>
        <div>
            <asp:GridView ID="ListeRisque" runat="server" AutoGenerateColumns="false" 
                ShowFooter="true" DataKeyNames="NumImmat"
                ShowHeaderWhenEmpty="true"
               
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                CellPadding="3"   style="margin-right: 10px">
                <%-- Theme Properties --%>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" Font-Size="Small" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
                
  <Columns>
  
     <asp:TemplateField HeaderText="Numéro Plaque">
     <ItemTemplate>
     <asp:Label Text='<%# Eval("NumImmat") %>' runat="server" />
     </ItemTemplate>
     <EditItemTemplate>
     <asp:TextBox ID="numplaque" Text='<%# Eval("NumImmat") %>' runat="server" />
     </EditItemTemplate>
     </asp:TemplateField>
         <asp:TemplateField HeaderText="Numéro Contrat ">
         <ItemTemplate>
         <asp:Label Text='<%# Eval("ContratAssocié") %>' runat="server" />
         </ItemTemplate>
         <EditItemTemplate>
         <asp:TextBox ID="numcontrat" Text='<%# Eval("ContratAssocié") %>' runat="server" />
         </EditItemTemplate>
         </asp:TemplateField>
             <asp:TemplateField HeaderText="Etat Risque ">
             <ItemTemplate>
             <asp:Label Text='<%# Eval("Etat") %>' runat="server" />
             </ItemTemplate>
             <EditItemTemplate>
             <asp:TextBox ID="etat" Text='<%# Eval("Etat") %>' runat="server" />
             </EditItemTemplate>
             </asp:TemplateField>                  
                     <asp:TemplateField HeaderText="CIN Assuré ">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("IdAssuré") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="idassure" Text='<%# Eval("IdAssuré") %>' runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Date Debut ">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("DateValiditéDebut") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="datevaldebut" Text='<%# Eval("DateValiditéDebut") %>' runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Date Fin ">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("DateValiditéFin") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="datevalfin" Text='<%# Eval("DateValiditéFin") %>' runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Marque ">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Marque") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="marque" Text='<%# Eval("Marque") %>' runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Classe">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Classe") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="classe" Text='<%# Eval("Classe") %>' runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Type ">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Type") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="type" Text='<%# Eval("Type") %>' runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Numéro serie ">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("NumSerie") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="numserie" Text='<%# Eval("NumSerie") %>' runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Puissance Fiscale ">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("PuissanceFiscale") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="puissancefiscale" Text='<%# Eval("PuissanceFiscale") %>' runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Nombre Place">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("NbPlace") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="nbplace" Text='<%# Eval("NbPlace") %>' runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Valeur Neuf ">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("ValeurNeuf") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="valeurneuf" Text='<%# Eval("ValeurNeuf") %>' runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Valeur Vénale ">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("ValeurVenale") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="valeurvenale" Text='<%# Eval("ValeurVenale") %>' runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Poids Vide ">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("PoidsVide") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="poidsvide" Text='<%# Eval("PoidsVide") %>' runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Poids Total ">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("PoidsTotal") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="poidstotal" Text='<%# Eval("PoidsTotal") %>' runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
            </asp:GridView>
            <br />
            <br />

        </div>
              </fieldset>
    </form>
</body>
</html>

   