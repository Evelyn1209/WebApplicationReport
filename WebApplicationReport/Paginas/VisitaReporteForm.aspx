<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisitaReporteForm.aspx.cs" Inherits="WebApplicationReport.view.VisitaReporteForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reporte</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:GridView ID="gvPersonas" runat="server" AutoGenerateColumns="false" BorderWidth="1">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Nombre" />
                    <asp:BoundField DataField="Age" HeaderText="Edad" />
                </Columns>
            </asp:GridView>

            <br />

            <asp:Button ID="btnPDF" runat="server" Text="Generar PDF" OnClick="btnPDF_Click" />

        </div>
    </form>
</body>
</html>
