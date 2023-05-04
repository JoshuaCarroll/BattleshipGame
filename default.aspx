<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="BattleshipRaygun._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Battleship</title>
    <style>
        @import url("https://fonts.googleapis.com/css2?family=Press+Start+2P&display=swap");

        h1 {
	        font-family: "Press Start 2P", monospace;
	        text-align: center;
	        text-transform: uppercase;
        }

        td,
        th {
	        border: 1px solid #000;
	        height: 50px;
	        width: 50px;
	        text-align: center;
	        font-size: 2em;
        }

        table {
	        text-align: center;
        }

        div {
	        margin: auto;
	        width: 1000px;
	        margin-bottom: 10px;
        }

        #tableContainer {
            height: 500px;
            width: 1000px;
            margin: auto;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Battleship</h1>
            <p>Your goal is to sink the two battleships. Guess their location by entering an X,Y coordinate. You only have 20 torpedoes, so use them wisely.</p>
            <div id="tableContainer">
            <asp:Table ID="Table1" runat="server" GridLines="Both">
                <asp:TableRow>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableHeaderCell>1</asp:TableHeaderCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableHeaderCell>2</asp:TableHeaderCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableHeaderCell>3</asp:TableHeaderCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableHeaderCell>4</asp:TableHeaderCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableHeaderCell>5</asp:TableHeaderCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableHeaderCell>6</asp:TableHeaderCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableHeaderCell>7</asp:TableHeaderCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableCell></asp:TableCell>
                    <asp:TableHeaderCell>8</asp:TableHeaderCell>
                </asp:TableRow>
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>1</asp:TableHeaderCell>
                    <asp:TableHeaderCell>2</asp:TableHeaderCell>
                    <asp:TableHeaderCell>3</asp:TableHeaderCell>
                    <asp:TableHeaderCell>4</asp:TableHeaderCell>
                    <asp:TableHeaderCell>5</asp:TableHeaderCell>
                    <asp:TableHeaderCell>6</asp:TableHeaderCell>
                    <asp:TableHeaderCell>7</asp:TableHeaderCell>
                    <asp:TableHeaderCell>8</asp:TableHeaderCell>
                    <asp:TableHeaderCell> </asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            </div>
        </div>
        <div>
            Torpedoes: <asp:Label ID="lblTorpedoes" runat="server" Text="🚀🚀🚀🚀🚀🚀🚀🚀🚀🚀🚀🚀🚀🚀🚀🚀🚀🚀🚀🚀"></asp:Label>
        </div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Firing solution: "></asp:Label><asp:TextBox ID="txtCoords" ClientIDMode="Static" runat="server"></asp:TextBox><asp:Button ID="btnFire" ClientIDMode="Static" runat="server" Text="Fire!" OnClick="btnFire_Click" />
        </div>
        <div>
            <asp:Label ID="lblFeedback" runat="server" Text=""></asp:Label></div>
        <asp:HiddenField ID="hdnGuessesLeft" runat="server" Value="20" />
    </form>
    <script language="Javascript">
        var txtCoords = document.getElementById("txtCoords");
        txtCoords.addEventListener("keypress", txtCoords_keypress);
        txtCoords.focus();

        function txtCoords_keypress(e) {
            if (e.keyCode == 13) {
                btnFire.click();
                return false;
            }
            else if ((e.keyCode == 44) || (e.keyCode > 48 && e.keyCode < 57)) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
</body>
</html>
