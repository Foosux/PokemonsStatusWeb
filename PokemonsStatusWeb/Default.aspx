<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" async="true" CodeBehind="Default.aspx.cs" Inherits="DXWebApplication2._Default"%>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
<br />
<p>
<dx:ASPxTextBox ID="UserName" runat="server" Width="270px" HelpText="Ptc�˺�"></dx:ASPxTextBox>
<dx:ASPxTextBox ID="Password" runat="server" Width="270px" HelpText="Ptc����" Text="" Password="True"></dx:ASPxTextBox>
<dx:ASPxButton ID="PtcSubmit" runat="server" Text="Ptc�˺ŵ�¼" OnClick="PtcSubmit_Click" Height="40px" Width="200px"></dx:ASPxButton>
</p>
    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="�ȸ��˺��Ȼ�ȡ��֤�룬�ٴ�www.google.com/device ������֤�����Google��¼��"></dx:ASPxLabel>
<p>
<dx:ASPxButton ID="GetGoogleCaptcha" runat="server" Text="�����֤��" Height="40px" Width="200px" OnClick="GetGoogleCaptcha_Click"></dx:ASPxButton>
<dx:ASPxButton ID="GoogleSubmit" runat="server" Text="Google��¼" Height="40px" Width="200px" OnClick="GoogleSubmit_Click"></dx:ASPxButton>
    

<dx:ASPxLabel ID="Captcha" runat="server" Text="" ForeColor="#CC0000"></dx:ASPxLabel>
</p>
<p>
<dx:ASPxLabel ID="lab" runat="server" Font-Size="X-Large" Text="" ForeColor="#CC0000"></dx:ASPxLabel>
</p>

    <br />

    <dx:ASPxButton ID="ExportView" runat="server" Text="����Excel�ļ�" Height="40px" Width="200px" OnClick="ExportView_Click">
    </dx:ASPxButton>
    

    <dx:ASPxGridViewExporter ID="Exporter" runat="server" GridViewID="ASPxGridView1">
    </dx:ASPxGridViewExporter>
<dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" ClientInstanceName="ASPxGridView1"

    Width="100%">
    <SettingsAdaptivity AdaptivityMode="HideDataCells" />
    <SettingsPager PageSize="50" />
    <Settings ShowGroupPanel="True" />
    <SettingsDataSecurity AllowEdit="False" AllowDelete="False" AllowInsert="False" />
    
    <Columns>
        <dx:GridViewDataTextColumn Caption="Pokemon" FieldName="Pokemon" VisibleIndex="0">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="CreationTime" FieldName="CreationTime" VisibleIndex="1">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="LV" FieldName="LV" VisibleIndex="2">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="CP" FieldName="CP" VisibleIndex="3">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="MaxCP" FieldName="MaxCP" VisibleIndex="4">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="ATK" FieldName="ATK" VisibleIndex="5">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="DEF" FieldName="DEF" VisibleIndex="6">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="STA" FieldName="STA" VisibleIndex="7">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="CPPerfection" FieldName="CPPerfection" VisibleIndex="8">
            <PropertiesTextEdit DisplayFormatString="{0:F2}%">
            </PropertiesTextEdit>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn Caption="IVPerfection" FieldName="IVPerfection" VisibleIndex="9">
            <PropertiesTextEdit DisplayFormatString="{0:F2}%">
            </PropertiesTextEdit>
        </dx:GridViewDataTextColumn>
    </Columns>
    
    <Paddings Padding="0px" />
    <Border BorderWidth="0px" />
    <BorderBottom BorderWidth="1px" />
    <%-- DXCOMMENT: Configure ASPxGridView's columns in accordance with datasource fields --%>
</dx:ASPxGridView>
<br />        
    
</asp:Content>