<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListeUtilisateurs.aspx.cs" Inherits="Flotte.ListeUtilisateurs" %>

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
      <a href="AjouterGarantie.aspx">Ajouter Garantie</a>
      <a href="ListeGaranties.aspx">Liste des Usages</a>
      
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

            <asp:GridView ID="ListeUtilisateur" runat="server" AutoGenerateColumns="false"  DataKeyNames="Login"
                ShowHeaderWhenEmpty="true"
                OnRowUpdating="ListeUtilisateur_RowUpdating"
               

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
                <asp:TemplateField HeaderText="Code">
                <ItemTemplate>
                <asp:Label Text='<%# Eval("Code") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                <asp:TextBox ID="code" Text='<%# Eval("Code") %>' runat="server" />
                </EditItemTemplate>                
                </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nom">
                        <ItemTemplate>
                        <asp:Label Text='<%# Eval("Nom") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                        <asp:TextBox ID="nom" Text='<%# Eval("Nom") %>' runat="server" />
                        </EditItemTemplate>                     
                        </asp:TemplateField>
                                <asp:TemplateField HeaderText="Prenom">
                                <ItemTemplate>
                                <asp:Label Text='<%# Eval("Prenom") %>' runat="server" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                <asp:TextBox ID="prenom" Text='<%# Eval("Prenom") %>' runat="server" />
                                </EditItemTemplate>                              
                                </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Telephone">
                                         <ItemTemplate>
                                         <asp:Label Text='<%# Eval("Telephone") %>' runat="server" />
                                         </ItemTemplate>
                                         <EditItemTemplate>
                                         <asp:TextBox ID="tel" Text='<%# Eval("Telephone") %>' runat="server" />
                                         </EditItemTemplate>                                        
                                         </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Login">
                                                <ItemTemplate>
                                                <asp:Label Text='<%# Eval("Login") %>' runat="server" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                <asp:TextBox ID="login" Text='<%# Eval("Login") %>' runat="server" />
                                                </EditItemTemplate>
                                             
                                                </asp:TemplateField>
                                                       
                                                                <asp:TemplateField HeaderText="Role">
                                                                <ItemTemplate>
                                                                <asp:Label Text='<%# Eval("Role") %>' runat="server" />
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                <asp:TextBox ID="role" Text='<%# Eval("Role") %>' runat="server" />
                                                                </EditItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                      
                                                                             <asp:ImageButton ImageUrl="~/Images/block.png" runat="server" CommandName="Update" ToolTip="Block" Width="20px" Height="20px"/>
                                                                            
                                                                        </ItemTemplate>
                                                                         </asp:TemplateField>
                                                                            
</Columns>
            </asp:GridView>
      

        </div>
        <asp:Label ID="Succes" runat="server" ForeColor="Green"></asp:Label>
        <br />
        <asp:Label ID="Erreur" runat="server" ForeColor="Red"></asp:Label>
    </form>
</body>
</html>

