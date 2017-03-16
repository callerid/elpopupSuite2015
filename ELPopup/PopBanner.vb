Public Class PopBanner

    Protected Overrides ReadOnly Property ShowWithoutActivation() As Boolean
        Get
            Return True
        End Get
    End Property

    Public Property PopupText()
        Get
            Return lblPopuptext.Text
        End Get
        Set(ByVal value)
            Me._popupText = value
            Me.Text = value
        End Set
    End Property

    Public WriteOnly Property Position()
        Set(ByVal value)
            Me._left = 0
            Me._top = lblPopuptext.Height * value + (5 * value)
        End Set
    End Property
    Private _top As Integer
    Private _left As Integer
    Private _popupText As String
    Private bDragging As Boolean = False
    Public timeLife As Integer = 300
    Public timeFadeRate As Double = 0.03
    Private WithEvents timer As New Timer
    Private Sub timer_tick() Handles timer.Tick
        If timeLife > 0 Then
            timeLife -= 1
        Else
            If bDragging = False Then
                If Math.Round(Me.Opacity - timeFadeRate, 3) < 0.01 Then
                    Me.Close()
                    Exit Sub
                End If
                Me.Opacity = Math.Round(Me.Opacity - timeFadeRate, 3)
            Else
            End If
        End If
        If Me.Opacity < 0.05 Then
            timer.Stop()
            Me.Close()
            Me.Dispose()
        End If
    End Sub
    Private Sub PopBanner_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = Me._top
        Me.Left = Me._left
        lblPopuptext.Text = Me._popupText
        Me.Height = lblPopuptext.Height
        Me.Width = lblPopuptext.Width
        timer.Interval = 10
        timer.Start()
    End Sub

    Private Sub lblPopuptext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPopuptext.Click
        For Each plugIn As CIDClass.IMyPlugIn In Form1.pluginList
            Dim result As Object
            result = plugIn.EventFunction(Form1.PluginValues.POPUP_CLICKED, Me.Text)
            If TypeOf (result) Is Boolean Then
                If result = True Then Me.Close()
            End If
        Next
    End Sub
End Class