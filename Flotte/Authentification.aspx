<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Authentification.aspx.cs" Inherits="Flotte.Authentification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
     <script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"></script>
   <script src="script.js"></script>
     
<head runat="server">
    <script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"></script>
   <script src="script.js"></script>
    <title></title>
    <style type="text/css">
        #Select1 {
            width: 129px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
          <fieldset style="height: 500px">
    <div>
        <h1>Authentification</h1>
    
    </div>
              
       <p>
         <asp:Label ID="Label1" runat="server" Text="Login :"></asp:Label>
         <asp:Label ID="LoginErreur" runat="server" ForeColor="Red"></asp:Label>
       </p>
          
        <p>
            <asp:TextBox ID="Login" runat="server" Height="20px" Width="116px"  ></asp:TextBox>
        </p>
            <p>
                <asp:Label ID="Label2" runat="server" Text="Mot de passe :"></asp:Label>
                <asp:Label ID="MdpErreur" runat="server" ForeColor="Red"></asp:Label>
            </p>
             <p>
                 <asp:TextBox ID="mdp" runat="server"  TextMode="Password" Height="22px" Width="116px" ></asp:TextBox>
            </p>
              <p>
            <asp:Label ID="Erreur" runat="server" ForeColor="Red"></asp:Label>
             </p>
            <p>
                  <asp:Button ID="Connexion" runat="server" Height="22px" OnClick="Verifier" Text="Connexion" />
                  <asp:Button ID="Connexion0" runat="server" Height="22px" OnClick="Annuler" Text="Annuler" />
             </p>
              </fieldset>
    </form>
</body>
</html>
