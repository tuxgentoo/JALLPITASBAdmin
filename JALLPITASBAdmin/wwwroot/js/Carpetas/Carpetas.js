//Scrip para obtener todas las Provincias segun Departamento
//<script>
$(function () {
    $("#DepartamentoId").change(function () {  
        //$('#MunicipioId').html("");
        var url = 'GetProvinciabyid';
        var ddlsource = "#DepartamentoId";        
        $.getJSON(url, { id: $(ddlsource).val() }, function (data) {
            var items = '<option selected="selected" value="" disabled>--Seleccione la provincia--</option>';            
            $("#ProvinciaId").empty();            
            $.each(data, function (i, row) {                
                items += "<option value='" + row.value + "'>" + row.text + "</option>";                   
            });
            $("#ProvinciaId").html(items);            
        })
        //$('#MunicipioId').append('<option selected="selected" value="" disabled>--Seleccione el municipio--</option>');
        $("#ProvinciaId").val("");
        $("#MunicipioId").val("");        
    });
});
//</script>

//Scrip para obtener todas los Municipios segun Una Provincia 
//<script>
$(function () {
    $("#ProvinciaId").change(function () {        
        var url = 'GetMunicipiobyid';
        var ddlsource = "#ProvinciaId";
        $.getJSON(url, { id: $(ddlsource).val() }, function (data) {
            var items = '<option selected="selected" value="" disabled>--Seleccione el municipio--</option>';
            items += '';            
            $("#MunicipioId").empty();
            $.each(data, function (i, row) {
                items += "<option value='" + row.value + "'>" + row.text + "</option>";
            });
            $("#MunicipioId").html(items);
        })
    });
});
//</script>