<template>
    <div id="feed">
        <span v-for="message of messages" v-bind:key="message">
            <div class="nameTag">{{message.author}}</div>
            <div class="messageContent">{{message.message}}</div>
        </span>
    </div>
</template>

<script>
    export default {
        computed: {
            messages(){
                return this.$store.getters.allMessages;
            }
        }
    }
</script>

<style lang="scss">
#feed {
    width: 70vw;
    height: 70vh;
    display: inline;
    border: 1px solid #000;
    margin-bottom: 20px;
    float: left;
    margin-left: 15vw;
    text-align: left;
    padding-left: 20px;
    padding-top: 10px;
    overflow: scroll;
}

.nameTag {
    font-weight: 900;
}

.messageContent {
    margin-left: 10px;
    margin-bottom: 20px;
}
</style>