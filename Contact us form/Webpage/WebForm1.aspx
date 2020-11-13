<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Webpage.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contact Us</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" integrity="sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN" crossorigin="anonymous">
    <script src="https://kit.fontawesome.com/8148383c3c.js" crossorigin="anonymous"></script>
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container">
                <div class="contact-parent">
                    <div class="contact-child child1">
                        <p>
                            <i class="fas fa-map-marker-alt"></i> Address <br />
                            <span> 2417 Dundas West street
                                <br />
                                Toronto, ON
                            </span>
                        </p>
                        <p>
                            <i class="fas fa-phone-alt"></i> Let's talk <br />
                            <span>6476765691</span>
                        </p>
                        <p>
                            <i class="far fa-envolope"></i> General Support <br />
                            <span>2021rosana2021@gmail.com</span>
                        </p>
                    </div>

                    <div class="contact-child child2">
                        <div class="inside-contact">
                            <h2>Contact Us</h2>
                            <h3>
                            <asp:Label ID="confirm" runat="server" Text="We'd love to hear from you, please drop us a line if you've any query."></asp:Label>
                                </h3>
                            <p>Name *</p>
                            <asp:TextBox ID="txt_name" runat="server" Required="required"></asp:TextBox>

                            <p>Email *</p>
                            <asp:TextBox ID="txt_email" runat="server" Required="required"></asp:TextBox>

                            <p>Phone *</p>
                            <asp:TextBox ID="txt_phone" runat="server" Required="required"></asp:TextBox>

                            <p>Subject *</p>
                            <asp:TextBox ID="txt_subject" runat="server" Required="required"></asp:TextBox>

                            <p>Message *</p>
                            <asp:TextBox ID="txt_message" runat="server" Required="required" TextMode="MultiLine" Rows="4"></asp:TextBox>

                            <asp:Button ID="btn_send" runat="server" Text="SEND" OnClick="btn_send_Click" />

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
