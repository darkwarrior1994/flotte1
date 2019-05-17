<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contrats.aspx.cs" Inherits="Flotte.Contrats" %>

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
           
           
      
        <div>
            <asp:GridView ID="ListeContrat" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="NumPolice"
                ShowHeaderWhenEmpty="true"
                 OnRowUpdating="ListeContrat_RowUpdating"
               
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Height="350px" Width="700px" style="margin-right: 10px">
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
      <asp:TemplateField HeaderText="Etat">
         <ItemTemplate>
         <asp:Label Text='<%# Eval("Etat") %>' runat="server" />
         </ItemTemplate>
         <EditItemTemplate>
         <asp:TextBox ID="etat" Text='<%# Eval("Etat") %>' runat="server" />
         </EditItemTemplate>                
         </asp:TemplateField>       
             <asp:TemplateField HeaderText="Numéro du police ">
             <ItemTemplate>
             <asp:Label Text='<%# Eval("NumPolice") %>' runat="server" />
             </ItemTemplate>
             <EditItemTemplate>
             <asp:TextBox ID="numpolice" Text='<%# Eval("NumPolice") %>' runat="server" />
             </EditItemTemplate>
             </asp:TemplateField>                    
                     <asp:TemplateField HeaderText="Agent Responsable ">
                     <ItemTemplate>
                     <asp:Label Text='<%# Eval("AgentResponsable") %>' runat="server" />
                      </ItemTemplate>
                      <EditItemTemplate>
                      <asp:TextBox ID="agentresponsable" Text='<%# Eval("AgentResponsable") %>' runat="server" />
                     </EditItemTemplate>
                        </asp:TemplateField>                       
                             <asp:TemplateField HeaderText="Raison Social Client ">
                             <ItemTemplate>
                             <asp:Label Text='<%# Eval("RaisonSocialClient") %>' runat="server" />
                             </ItemTemplate>
                             <EditItemTemplate>
                             <asp:TextBox ID="raisonsocialclient" Text='<%# Eval("RaisonSocialClient") %>' runat="server" />
                             </EditItemTemplate>
                             </asp:TemplateField>  
                                    <asp:TemplateField HeaderText="Code Client ">
                                    <ItemTemplate>
                                    <asp:Label Text='<%# Eval("CodeClient") %>' runat="server" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                    <asp:TextBox ID="codeclient" Text='<%# Eval("CodeClient") %>' runat="server" />
                                    </EditItemTemplate>
                                    </asp:TemplateField>  
                                         <asp:TemplateField HeaderText="Date Effet Debut ">
                                         <ItemTemplate>
                                         <asp:Label Text='<%# Eval("DateEffetDebut") %>' runat="server" />
                                         </ItemTemplate>
                                        <EditItemTemplate>
                                     <asp:TextBox ID="dateeffetdebut" Text='<%# Eval("DateEffetDebut") %>' runat="server" />
                                     </EditItemTemplate>
                                     </asp:TemplateField>  
                                             <asp:TemplateField HeaderText="Date Effet Fin ">
                                             <ItemTemplate>
                                             <asp:Label Text='<%# Eval("DateEffetFin") %>' runat="server" />
                                             </ItemTemplate>
                                             <EditItemTemplate>
                                             <asp:TextBox ID="dateeffetfin" Text='<%# Eval("DateEffetFin") %>' runat="server" />
                                             </EditItemTemplate>
                                             </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Prime Provisoire ">
                                                             <ItemTemplate>
                                                             <asp:Label Text='<%# Eval("PrimeProvisoire") %>' runat="server" />
                                                             </ItemTemplate>
                                                             <EditItemTemplate>
                                                             <asp:TextBox ID="primeprovisoire" Text='<%# Eval("PrimeProvisoire") %>' runat="server" />
                                                             </EditItemTemplate>
                                                             </asp:TemplateField> 
                                                                     <asp:TemplateField>
                                                                         <ItemTemplate>
                                                                             <asp:ImageButton ImageUrl="~/Images/block.png" runat="server" CommandName="Update" ToolTip="Blocage/Déblocage" Width="20px" Height="20px"/>                                                                            
                                                                        </ItemTemplate>
                                                                         </asp:TemplateField>                   
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="Succes" runat="server" ForeColor="Green" />
            <br />
            <asp:Label ID="Erreur" runat="server" ForeColor="Red" />

        </div>
         </fieldset>
    </form>
</body>
</html>

   
 