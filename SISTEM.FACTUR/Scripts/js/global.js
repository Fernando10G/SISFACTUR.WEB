function Post(url, paramss) {
	return ajaxMethod(url, "POST", paramss);
}

function ajaxMethod(url, method, paramss) {
	return $.ajax({
		url: window.appURL + url,
		method: method,
		async: false,
		cache: false,
		data: paramss,  
	}).fail(function (jqXHR, textStatus, errorThrown){
		console.debug(jqXHR);
		console.debug(textStatus);
		console.debug(errorThrown);
	})
}


function fnBaseURLWeb(url) {
	return window.appURL + url

}

/** Para enviar archivos al controlador*/
function PostImg(url, params) {
	return ajaxMethodImg(url, "POST", params);

}
function ajaxMethodImg(url, method, params) {
	return $.ajax({
		url: window.appURL + url,
		method: method,
		async: false,
		processData: false,
		contentType: false,
		cache: false,
		data: params

	}).fail(function (jqXHR, textStatus, errorThrown) {
		console.debug(jqXHR);
		console.debug(textStatus);
		console.debug(errorThrown);
	})
}

function finBaseURLWeb(url) {
		return window.appURL + url
	}
 
