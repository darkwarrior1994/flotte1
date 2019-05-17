<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GarantiesCouvertes.aspx.cs" Inherits="Flotte.GarantiesCouvertes" %>

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
      <p>
            <asp:Button ID="Button2" runat="server" OnClick="Affecter" Text="Affecter Garantie" />
        </p>
        <asp:GridView ID="ListeGarantie" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="Id"
                ShowHeaderWhenEmpty="true"
               
                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Height="350px" Width="700px" style="margin-right: 10px">
                <%-- Theme Properties --%>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
                
  <Columns>
  <asp:TemplateField HeaderText="Id">
  <ItemTemplate>
  <asp:Label Text='<%# Eval("Id") %>' runat="server" />
  </ItemTemplate>
  <EditItemTemplate>
  <asp:TextBox ID="id" Text='<%# Eval("Id") %>' runat="server" />
  </EditItemTemplate>
  </asp:TemplateField>
     <asp:TemplateField HeaderText="Numéro Plaque">
     <ItemTemplate>
     <asp:Label Text='<%# Eval("IdRisque") %>' runat="server" />
     </ItemTemplate>
     <EditItemTemplate>
     <asp:TextBox ID="idrisque" Text='<%# Eval("IdRisque") %>' runat="server" />
     </EditItemTemplate>
     </asp:TemplateField>
         <asp:TemplateField HeaderText="Numéro Contrat Associé  ">
         <ItemTemplate>
         <asp:Label Text='<%# Eval("IdContrat") %>' runat="server" />
         </ItemTemplate>
         <EditItemTemplate>
         <asp:TextBox ID="idcontrat" Text='<%# Eval("IdContrat") %>' runat="server" />
         </EditItemTemplate>
         </asp:TemplateField>
             <asp:TemplateField HeaderText="Etat Risque ">
             <ItemTemplate>
             <asp:Label Text='<%# Eval("EtatRisque") %>' runat="server" />
             </ItemTemplate>
             <EditItemTemplate>
             <asp:TextBox ID="etatrisque" Text='<%# Eval("EtatRisque") %>' runat="server" />
             </EditItemTemplate>
             </asp:TemplateField>
                    <asp:TemplateField HeaderText="Etat du Contrat associé ">
                    <ItemTemplate>
                    <asp:Label Text='<%# Eval("EtatContrat") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                    <asp:TextBox ID="etatcontrat" Text='<%# Eval("EtatContrat") %>' runat="server" />
                    </EditItemTemplate>
                    </asp:TemplateField>        
                             <asp:TemplateField HeaderText="Ordre Risque ">
                             <ItemTemplate>
                             <asp:Label Text='<%# Eval("OrdreRisque") %>' runat="server" />
                             </ItemTemplate>
                             <EditItemTemplate>
                             <asp:TextBox ID="ordrerisque" Text='<%# Eval("OrdreRisque") %>' runat="server" />
                             </EditItemTemplate>
                             </asp:TemplateField>               
                                     <asp:TemplateField HeaderText="Ordre du Contrat associé ">
                                     <ItemTemplate>
                                     <asp:Label Text='<%# Eval("OrdreContrat") %>' runat="server" />
                                     </ItemTemplate>
                                     <EditItemTemplate>
                                     <asp:TextBox ID="ordrecontrat" Text='<%# Eval("OrdreContrat") %>' runat="server" />
                                     </EditItemTemplate>
                                     </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Garantie Legale ">
                                            <ItemTemplate>
                                            <asp:Label Text='<%# Eval("LibelleGar1") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                            <asp:TextBox ID="garrc" Text='<%# Eval("LibelleGar1") %>' runat="server" />
                                            </EditItemTemplate>
                                            </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Grarantie Contractuelle">
                                                    <ItemTemplate>
                                                    <asp:Label Text='<%# Eval("LibelleGar2") %>' runat="server" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                    <asp:TextBox ID="garincendie" Text='<%# Eval("LibelleGar2") %>' runat="server" />
                                                    </EditItemTemplate>
                                                    </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Grarantie Contractuelle">
                                                            <ItemTemplate>
                                                            <asp:Label Text='<%# Eval("LibelleGar3") %>' runat="server" />
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                            <asp:TextBox ID="garvol" Text='<%# Eval("LibelleGar3") %>' runat="server" />
                                                            </EditItemTemplate>
                                                            </asp:TemplateField> 
                                                                    <asp:TemplateField HeaderText="Grarantie Contractuelle">
                                                                    <ItemTemplate>
                                                                    <asp:Label Text='<%# Eval("LibelleGar4") %>' runat="server" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                    <asp:TextBox ID="garcas" Text='<%# Eval("LibelleGar4") %>' runat="server" />
                                                                    </EditItemTemplate>
                                                                    </asp:TemplateField>      
                                                                            <asp:TemplateField HeaderText="Grarantie Contractuelle">
                                                                            <ItemTemplate>
                                                                            <asp:Label Text='<%# Eval("LibelleGar5") %>' runat="server" />
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                            <asp:TextBox ID="gartiercesf" Text='<%# Eval("LibelleGar5") %>' runat="server" />
                                                                            </EditItemTemplate>
                                                                            </asp:TemplateField> 
                                                                                    <asp:TemplateField HeaderText="Grarantie Contractuelle">
                                                                                    <ItemTemplate>
                                                                                    <asp:Label Text='<%# Eval("LibelleGar6") %>' runat="server" />
                                                                                    </ItemTemplate>
                                                                                    <EditItemTemplate>
                                                                                    <asp:TextBox ID="gartierceaf" Text='<%# Eval("LibelleGar6") %>' runat="server" />
                                                                                    </EditItemTemplate>
                                                                                    </asp:TemplateField> 
                                                                                            <asp:TemplateField HeaderText="Prime RC">
                                                                                            <ItemTemplate>
                                                                                            <asp:Label Text='<%# Eval("PrimeRC") %>' runat="server" />
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                            <asp:TextBox ID="primerc" Text='<%# Eval("PrimeRC") %>' runat="server" />
                                                                                            </EditItemTemplate>
                                                                                            </asp:TemplateField> 
                                                                                                    <asp:TemplateField HeaderText="Prime INCENDIE">
                                                                                                    <ItemTemplate>
                                                                                                    <asp:Label Text='<%# Eval("PrimeIncendie") %>' runat="server" />
                                                                                                    </ItemTemplate>
                                                                                                    <EditItemTemplate>
                                                                                                    <asp:TextBox ID="primeincendie" Text='<%# Eval("PrimeIncendie") %>' runat="server" />
                                                                                                    </EditItemTemplate>
                                                                                                    </asp:TemplateField> 
                                                                                                            <asp:TemplateField HeaderText="Prime VOL">
                                                                                                            <ItemTemplate>
                                                                                                            <asp:Label Text='<%# Eval("PrimeVol") %>' runat="server" />
                                                                                                            </ItemTemplate>
                                                                                                            <EditItemTemplate>
                                                                                                            <asp:TextBox ID="primevol" Text='<%# Eval("PrimeVol") %>' runat="server" />
                                                                                                            </EditItemTemplate>
                                                                                                            </asp:TemplateField> 
                                                                                                                    <asp:TemplateField HeaderText="Prime CAS">
                                                                                                                    <ItemTemplate>
                                                                                                                    <asp:Label Text='<%# Eval("PrimeCas") %>' runat="server" />
                                                                                                                    </ItemTemplate>
                                                                                                                    <EditItemTemplate>
                                                                                                                    <asp:TextBox ID="primecas" Text='<%# Eval("PrimeCas") %>' runat="server" />
                                                                                                                    </EditItemTemplate>
                                                                                                                    </asp:TemplateField>  
                                                                                                                            <asp:TemplateField HeaderText="Prime TIERCE SF">
                                                                                                                            <ItemTemplate>
                                                                                                                            <asp:Label Text='<%# Eval("PrimeTierceSf") %>' runat="server" />
                                                                                                                            </ItemTemplate>
                                                                                                                            <EditItemTemplate>
                                                                                                                            <asp:TextBox ID="primetiercesf" Text='<%# Eval("PrimeTierceSf") %>' runat="server" />
                                                                                                                            </EditItemTemplate>
                                                                                                                            </asp:TemplateField> 
                                                                                                                                    <asp:TemplateField HeaderText="Prime TIERCE AF">
                                                                                                                                    <ItemTemplate>
                                                                                                                                    <asp:Label Text='<%# Eval("PrimeTierceAf") %>' runat="server" />
                                                                                                                                    </ItemTemplate>
                                                                                                                                    <EditItemTemplate>
                                                                                                                                    <asp:TextBox ID="primetierceaf" Text='<%# Eval("PrimeTierceAf") %>' runat="server" />
                                                                                                                                    </EditItemTemplate>
                                                                                                                                    </asp:TemplateField> 
                                                                                                                                            <asp:TemplateField HeaderText="Prime Totale">
                                                                                                                                            <ItemTemplate>
                                                                                                                                            <asp:Label Text='<%# Eval("PrimeTotale") %>' runat="server" />
                                                                                                                                            </ItemTemplate>
                                                                                                                                            <EditItemTemplate>
                                                                                                                                            <asp:TextBox ID="primetotale" Text='<%# Eval("PrimeTotale") %>' runat="server" />
                                                                                                                                            </EditItemTemplate>
                                                                                                                                            </asp:TemplateField>                                                                           
</Columns>
            </asp:GridView>
            <br />
            <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="Green" />
            <br />
            <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red" />
      </fieldset>
    </form>
</body>
</html>

   

