/*!
 * easion - Bootstrap dashboard template based on Bootstrap 4
 * Version v1.0.1
 * Copyright 2016 - 2020 Mudimedia Software
 * https://mudimedia.com
 */

const mobileBreakpoint = window.matchMedia("(max-width: 991px )");
var _api = "http://localhost:55867/api/";
$(document).ready(function () {
    var kisiler = Array();
    var iletisim = Array();
  
    $(".dash-nav-dropdown-toggle").click(function(){
        $(this).closest(".dash-nav-dropdown")
            .toggleClass("show")
            .find(".dash-nav-dropdown")
            .removeClass("show");

        $(this).parent()
            .siblings()
            .removeClass("show");
    });

    $(".menu-toggle").click(function(){
        if (mobileBreakpoint.matches) {
            $(".dash-nav").toggleClass("mobile-show");
        } else {
            $(".dash").toggleClass("dash-compact");
        }
    });

    $("#goster").click(function () {
  
    });

    

    $("#ekle").click(function () {
        var arr = $('form#yeni_kisi').serializeArray();
        var veri = {};
        arr.forEach(function (a) {
            veri[a['name']] = a['value'];
        });


        if ($("#ekle")[0].innerHTML == "Guncelle") {
            veri['uuid'] = parseInt(veri['uuid']);
            $.ajax({
                url: _api + 'Kisiler/update/',
                type: 'put',
                dataType: 'json',
                data: JSON.stringify(veri),
                contentType: 'application/json',
                success: function (data) {
                    if (data == true) {
                        kisileri_getir();
                        $('form#yeni_kisi')[0].reset();
                        $("#yeni_kisi_modal .close").click();
                        $("#ekle")[0].innerHTML = "Ekle";
                        $("#kisiekletitle")[0].innerHTML = "Kisi Ekle";
                    } else {
                        alert("Bir Hata Olustu");
                    }
                }
            });
        } else {
            delete (veri['uuid']) ;
            $.ajax({
                url: _api + 'Kisiler/add',
                type: 'post',
                dataType: 'json',
                data: JSON.stringify(veri),
                contentType: 'application/json',
                success: function (data) {
                    if (data == true) {
                        kisileri_getir();
                        $('form#yeni_kisi')[0].reset();
                        $("#yeni_kisi_modal .close").click();
                    } else {
                        alert("Bir Hata Olustu");
                    }
                }
            });
        }


 

    });
     
    $("#iletisimekle").click(function () {
        var arr = $('form#yeni_iletisim').serializeArray();
        var veri = {};
        arr.forEach(function (a) {
            veri[a['name']] = a['value'];
        });
        veri['KID'] = parseInt(veri['KID']);
        veri['IID'] = parseInt(veri['IID']);

        if ($("#iletisimekle")[0].innerHTML == "Guncelle") {
           
            $.ajax({
                url: _api + 'Iletisim/update/',
                type: 'put',
                dataType: 'json',
                data: JSON.stringify(veri),
                contentType: 'application/json',
                success: function (data) {
                    if (data == true) {
                        iletisim_goster(veri['KID']);
                        $('form#yeni_iletisim')[0].reset();
                        $("#yeni_iletisim_modal .close").click();
                        $("#iletisimekle")[0].innerHTML = "Ekle";
                        $("#iletisimekletitle")[0].innerHTML = "Kisi Ekle";
                    } else {
                        alert("Bir Hata Olustu");
                    }
                }
            });
        } else {
            delete (veri['IID']);
            $.ajax({
                url: _api + 'Iletisim/add',
                type: 'post',
                dataType: 'json',
                data: JSON.stringify(veri),
                contentType: 'application/json',
                success: function (data) {
                    if (data == true) {
                        iletisim_goster(veri['KID']);
                        $('form#yeni_iletisim')[0].reset();
                        $("#yeni_iletisim_modal .close").click();
                    } else {
                        alert("Bir Hata Olustu");
                    }
                }
            });
        }




    });


});

function yenikisititle() {
    $('form#yeni_kisi')[0].reset();
    $("#ekle")[0].innerHTML = "Ekle";
    $("#kisiekletitle")[0].innerHTML = "Kisi Ekle";
}
function kisi_sil(id) {
    
    $.ajax({
        url: _api + 'Kisiler/delete/' + id,
        type: 'delete',
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            if (data == true) {
                kisileri_getir();
            } else {
                alert("Bir Hata Olustu");
            }
        }
    });

}

function kisi_guncelle(id) {

    kisiler.forEach(function (a) {
        if (a['uuid'] == id) {
            $('#uuid').val(a['uuid']);
            $('#inputadi').val(a['ad']);
            $('#inputsoyadi').val(a['soyad']);
            $('#inputfirma').val(a['firma']);
     
        }
    });

    $("#yeni_kisi_modal").modal('show');
    $("#ekle")[0].innerHTML="Guncelle";
    $("#kisiekletitle")[0].innerHTML="Guncelle";

}

function iletisim_guncelle(id) {

    iletisim.forEach(function (a) {
        if (a['iid'] == id) {
            $('#KID').val(a['kid']);
            $('#IID').val(a['iid']);
            $('#inputtelefon').val(a['telefon']);
            $('#inputemail').val(a['email']);
            $('#inputkonum').val(a['konum']);
        }
    });

    $("#yeni_iletisim_modal").modal('show');
    $("#iletisimekle")[0].innerHTML = "Guncelle";
    $("#iletisimekletitle")[0].innerHTML = "Guncelle";

}

function kisileri_getir() {
    document.getElementById('loader-wrapper').style.display = "block";
    $.ajax(_api + 'Kisiler/getList',   // request url       
        {

            success: function (data, status, xhr) {// success callback function

                document.getElementById('loader-wrapper').style.display = "none";
                var div = document.getElementById('kisi_list');
                kisiler = Array();
                div.innerHTML = "";
                var i = 0;
                data.forEach(function (a) {
                    kisiler.push(a);
                    i++;
                    var html = '<tr>' +
                        '<th scope = "row" > ' + i + '</th>' +
                        '<td>' + a['ad'] + '</td>' +
                        '<td>' + a['soyad'] + '</td>' +
                        '<td>' + a['firma'] + '</td>' +
                        '<td><button type="button" id="goster" onclick="iletisim_goster(' + a['uuid']+')" class="btn btn-success mb-1">Goster</button></td>' +
                        '<td><a href="javascript:void(0)" onclick="kisi_guncelle(' + a['uuid'] + ')"  class="btn btn-primary mb-1" > <i class="fas fa-edit"></i></a>' +
                        '<a href="javascript:void(0)"  onclick="kisi_sil(' + a['uuid'] +')" class="kisi_sil btn btn-danger  mb-1" data-id="' + a['uuid'] +'" ><i class="kisi_sil fas fa-trash-alt"></i> </a></td>' +
                        '</tr >';
                    var div = document.getElementById('kisi_list');
                    div.innerHTML += html;
                });
            }
        });



}


function iletisim_goster(id) {
    kisiler.forEach(function (a) {
        if (a['uuid'] == id) {      
            $('#KID').val(a['uuid']);
            kisiIletisimList_getir(id);
        }
    });   
}
function iletisimformtemizle() {
   
    $('form#yeni_iletisim')[0].reset();
    $("#iletisimekle")[0].innerHTML = "Ekle";
    $("#iletisimekletitle")[0].innerHTML = "Kisi Ekle";
}
function iletisim_sil(id) {
    $.ajax({
        url: _api + 'Iletisim/delete/' + id,
        type: 'delete',
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            if (data == true) {
                iletisim_goster($('#KID').val())
            } else {
                alert("Bir Hata Olustu");
            }
        }
    });
}

function kisiIletisimList_getir(id) {
    document.getElementById('loader-wrapper').style.display = "block";
    $.ajax(_api + 'Iletisim/getUserList/'+id,   // request url       
        {

            success: function (data, status, xhr) {// success callback function

                document.getElementById('loader-wrapper').style.display = "none";
                var div = document.getElementById('iletisim_list');
                iletisim = Array();
                div.innerHTML = "";
                var i = 0;
                data.forEach(function (a) {
                    iletisim.push(a);
                    i++;
                    var html = '<tr>' +
                        '<th scope = "row" > ' + i + '</th>' +
                        '<td>' + a['telefon'] + '</td>' +
                        '<td>' + a['email'] + '</td>' +
                        '<td>' + a['konum'] + '</td>' +                     
                        '<td><a href="javascript:void(0)" onclick="iletisim_guncelle(' + a['iid'] + ')"  class="btn btn-primary mb-1" > <i class="fas fa-edit"></i></a>' +
                        '<a href="javascript:void(0)"  onclick="iletisim_sil(' + a['iid'] + ')" class="kisi_sil btn btn-danger  mb-1" data-id="' + a['uuid'] + '" ><i class="kisi_sil fas fa-trash-alt"></i> </a></td>' +
                        '</tr >';
                    var div = document.getElementById('iletisim_list');
                    div.innerHTML += html;
                });
            }
        });


}function konum_rapor() {
    document.getElementById('loader-wrapper').style.display = "block";
    $.ajax(_api + 'Iletisim/rapor_konum_list',   // request url       
        {

            success: function (data, status, xhr) {// success callback function

                document.getElementById('loader-wrapper').style.display = "none";
                var div = document.getElementById('rapor_list');
              
                div.innerHTML = "";
                var i = 0;
                data.forEach(function (a) {
                    
                    i++;
                    var html = '<tr>' +
                        '<th scope = "row" > ' + i + '</th>' +
                        '<td>' + a['konum'] + '</td>' +
                        '<td>' + a['sayi'] + '</td>' +    
                        '<td>' + a['kisi_sayi'] + '</td>' +            
                        '<td>' + a['telefon_sayi'] + '</td>' +            
                        '</tr >';
                    var div = document.getElementById('rapor_list');
                    div.innerHTML += html;
                });
            }
        });


}