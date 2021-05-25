Public Class CSV

    Private csvfile As String
    '
    Public Property ArquivoCSV() As String
        Get
            Return csvfile
        End Get
        Set(ByVal value As String)
            csvfile = value
        End Set
    End Property

    Private csvfields As Integer
    '
    Public Property CamposCSV() As Integer
        Get
            Return csvfields
        End Get
        Set(value As Integer)
            csvfields = value
        End Set
    End Property

    Private csvcharseparator As Char
    '
    Public Property CaractereSeparador As Char
        Get
            Return csvcharseparator
        End Get
        Set(value As Char)
            csvcharseparator = value
        End Set
    End Property
    ''' <summary>
    ''' Inicia uma instância de arquivo .csv para edição.
    ''' </summary>
    ''' <param name="file">Caminho completo do arquivo .csv.</param>
    ''' <param name="fields">Número de campos que o arquivo .csv irá armazenar.</param>
    ''' <param name="CSVchar">Caractere separador. O padrão é ";".</param>
    ''' <remarks></remarks>
    Sub New(ByVal file As String, ByVal fields As Integer, Optional ByVal CSVchar As Char = ";")
        ArquivoCSV = file
        CamposCSV = fields
        CaractereSeparador = CSVchar
    End Sub

    Public Sub Adicionar_Registro(ByVal ParamArray values() As String)
        Dim fstr As IO.FileStream = New IO.FileStream(ArquivoCSV, IO.FileMode.Append)
        '
        Dim stw As IO.StreamWriter = New IO.StreamWriter(fstr)
        '
        If UBound(values) > 1 Then
            stw.Write(values(0))
        ElseIf UBound(values) = 1 Then
            stw.WriteLine(values(0))
            stw.Close()
            Return
        End If
        '
        For i As Integer = 1 To UBound(values)
            stw.Write(CaractereSeparador & values(i))
        Next
        stw.WriteLine()
        stw.Close()
    End Sub



End Class
