<!--Programmer: Shay Deshner -->
<!--Date: 2/19/2015 -->
<!--Assignment: Week 7 -->
<!--Professor: David Moore -->

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StronglyTyped_DetailsView.aspx.cs" Inherits="LINQ_example.StronglyTyped_DetailsView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 266px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<table border="1">
    <tr>
        <td>
            Customer ID
        </td>
        <td class="auto-style1">
            <asp:TextBox ID="txtCustomerID" runat="server"/>
            <asp:Button ID="btnGetCustomer" runat="server" Text="Load Record" 
                OnClick="btnGetCustomer_Click" Width="92px" />
        </td>
    </tr>
    <tr>
        <td>
            First Name
        </td>
        <td class="auto-style1">
            <asp:TextBox ID="txtFirstName" runat="server"/>
        </td>
    </tr>
    <tr>
        <td>
            Last Name
        </td>
        <td class="auto-style1">
            <asp:TextBox ID="txtLastName" runat="server"/>
        </td>
    </tr>

    <tr>
        <td>
            Gender
        </td>
        <td class="auto-style1">
            <asp:TextBox ID="txtGender" runat="server"/>
        </td>
    </tr>
    
    <tr>
        <td>
            City
        </td>
        <td class="auto-style1">
            <asp:TextBox ID="txtCity" runat="server"/>
        </td>
    </tr>
     <tr>
        <td>
            State
        </td>
        <td class="auto-style1">
            <asp:TextBox ID="txtState" runat="server"/>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Button ID="btnUpdate" runat="server" Text="Update" 
                OnClick="btnUpdate_Click" Width="84px" />
           
            <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" Width="84px" />
            <asp:Button ID="btnInsert" runat="server" OnClick="btnInsert_Click" Text="Insert" Width="85px" />
           
            <asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="Clear Fields" Width="85px" />
           
        </td>
    </tr>
</table>
</div>

        <p>
            <asp:Literal ID="litValidateMessage" runat="server"></asp:Literal>
        </p>

        <p>
            <asp:Button ID="btnDatabase" runat="server" Text="View Records in Database" Width="173px" OnClick="btnDatabase_Click" />
        </p>
        <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="LINQ_example.App_Code.CustomersDataContext" EnableDelete="True" EnableInsert="True" EnableUpdate="True" EntityTypeName="" Select="new (CustomerID, FirstName, LastName, Gender, City, State)" TableName="Customers" Where="CustomerID == @CustomerID &amp;&amp; FirstName == @FirstName &amp;&amp; LastName == @LastName &amp;&amp; Gender == @Gender &amp;&amp; City == @City &amp;&amp; State == @State">
            <UpdateParameters>
                <asp:ControlParameter ControlID="txtCustomerID" Name="newparameter" PropertyName="Text" />
                <asp:ControlParameter ControlID="txtFirstName" Name="newparameter" PropertyName="Text" />
                <asp:ControlParameter ControlID="txtLastName" Name="newparameter" PropertyName="Text" />
                <asp:ControlParameter ControlID="txtGender" Name="newparameter" PropertyName="Text" />
                <asp:ControlParameter ControlID="txtCity" Name="newparameter" PropertyName="Text" />
                <asp:ControlParameter ControlID="txtState" Name="newparameter" PropertyName="Text" />
            </UpdateParameters>
            <WhereParameters>
                <asp:ControlParameter ControlID="txtCustomerID" Name="CustomerID" PropertyName="Text" Type="Int32" />
                <asp:ControlParameter ControlID="txtFirstName" Name="FirstName" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txtLastName" Name="LastName" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txtGender" Name="Gender" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txtCity" Name="City" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txtState" Name="State" PropertyName="Text" Type="String" />
            </WhereParameters>
        </asp:LinqDataSource>
    </form>
</body>
</html>
