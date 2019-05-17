<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListeGaranties.aspx.cs" Inherits="Flotte.ListeGaranties" %>
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


            <asp:GridView ID="ListeGarantie" runat="server" AutoGenerateColumns="false"  DataKeyNames="IdGarantie"
                ShowHeaderWhenEmpty="true"
                
              OnRowDeleting="ListeGarantie_RowDeleting"


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
                    
                  
                         <asp:TemplateField HeaderText="Libelle">
                         <ItemTemplate>
                         <asp:Label Text='<%# Eval("LibelleGarantie") %>' runat="server" />
                         </ItemTemplate>
                         <EditItemTemplate>
                         <asp:TextBox ID="libelle" Text='<%# Eval("LibelleGarantie") %>' runat="server" />
                         </EditItemTemplate>
                        
                         </asp:TemplateField>                               
                            <asp:TemplateField HeaderText="IdGarantie">
                            <ItemTemplate>
                            <asp:Label Text='<%# Eval("IdGarantie") %>' runat="server" />
                            </ItemTemplate>
                            <EditItemTemplate>
                            <asp:TextBox ID="id" Text='<%# Eval("IdGarantie") %>' runat="server" />
                            </EditItemTemplate>
                        
                            </asp:TemplateField>

                            <asp:TemplateField>
                         <ItemTemplate>
                          
                            <asp:ImageButton ImageUrl="~/Images/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px"/>
                        </ItemTemplate>
                        
                       
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="Green" />
            <br />
            <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />

        
    </form>
</body>
</html>

