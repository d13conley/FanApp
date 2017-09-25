﻿class HomeFeedController {
    constructor($http, $stateParams, $state, $uibModal) {
        this.$http = $http;
        this.$state = $state;
		this.id = $stateParams["id"];
		sessionStorage.setItem("otherid", this.id);
		this.otherid = sessionStorage.getItem("otherid");
        this.user = sessionStorage.getItem("userid");
        this.getPostWithProfile();
        this.like = {
            UserId: this.id,
            PostId: this.post
        };
        this.getComments();
		this.$uibModal = $uibModal;
		this.postId = $stateParams["postId"];
		
    }

    getPostWithProfile() {
        this.$http.get("api/UserFollowers/postandprofile/" + this.user)
            .then(res => {
                this.post = res.data;
                console.log(res.data);
            });
	}

	likePost(postId) {
		this.$http.post("api/Likes/", { DateLiked: new Date(), UserId: this.user, PostId: postId })
			.then((res) => {

			});
	}
    AddComment(postId, text) {
        this.$http.post("api/Comments", { PostId: postId, Text: text, UserId: this.user })
            .then((res) => {

                this.$state.reload();
                console.log("comments");
            });
    }
    getComments() {
        this.$http.get("api/Comments/")
            .then(res => {
                this.comments = res.data;
                console.log(res.data);
            });
	}

	showModalComments(postId) {
		console.log(postId);
	// find out how to get $state, $http, etc from the angular IOC container, dependency injector
	// $inject
		//let controller = new ModelCommentController(postId); 
		this.$uibModal.open({
			templateUrl: '/ngApp/views/modalComments.html',
			controller: ModalCommentController,
			controllerAs: 'controller',
			resolve: {
				postId: () => this.postId
			},
			// is there another property to add arbitrary data?
		});
	}
}
 
class ModalCommentController {
    constructor(postId, $stateParams, $http, $state, $uibModalInstance) {
        this.$http = $http;
        this.$state = $state;
        this.modal = $uibModalInstance;
		this.postId = $stateParams["postId"]
        this.getComment();
	}

    getComment(postId) {
        this.$http.get("api/Comments/" + postId)
            .then(res => {
                
            });
    }
}
