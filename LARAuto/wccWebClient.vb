Imports System.Net
Public Class wccWebClient
    Inherits WebClient
    Private _timeout As Integer
    ''' <summary>
    ''' Time in milliseconds
    ''' </summary>
    Public Property Timeout() As Integer
        Get
            Return _timeout
        End Get
        Set(ByVal value As Integer)
            _timeout = value
        End Set
    End Property

    Public Sub New()
        Me._timeout = 60000
    End Sub

    Public Sub New(ByVal timeout As Integer)
        Me._timeout = timeout
    End Sub

    Protected Overrides Function GetWebRequest(ByVal address As Uri) As WebRequest
        Dim result = MyBase.GetWebRequest(address)
        result.Timeout = Me._timeout
        Return result
    End Function
End Class